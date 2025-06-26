using AidatTakip.Data.Abstract;
using AidatTakip.Data.Concrete.Entities;
using AidatTakip.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AidatTakip.Controllers
{
    public class ApartmanController : Controller
    {
        private readonly IApartmanRepository _apartmanRepo;
        private readonly ISiteRepository _siteRepo;
        private readonly IDaireRepository _daireRepo;
        private bool _isYeniKayit = false;
        public ApartmanController(IApartmanRepository apartmanRepo, ISiteRepository siteRepo, IDaireRepository daireRepo)
        {
            _apartmanRepo = apartmanRepo;
            _siteRepo = siteRepo;
            _daireRepo = daireRepo;
        }
        public IActionResult Index()
        {
            var viewModel = new ApartmanViewModel();
            viewModel.Apartmanlar = _apartmanRepo.Query()
                .Include(a => a.Daireler)
                .ToList();
            viewModel.Sites = _siteRepo.Query().ToList();
            return View(viewModel);
        }

        public async Task<IActionResult> Ekle(Apartman model)
        {
            if (model != null)
            {
                var site = await _siteRepo.GetByIdAsync(model.SiteId);
                if (model.SiteId != 0)
                {
                    if (site != null)
                    {
                        model.Site = site;
                    }
                    else
                    {
                        return BadRequest(new { success = false, message = "Geçersiz site seçimi." });
                    }
                }
                if (model.Id == 0)
                {
                    await _apartmanRepo.AddAsync(model);
                    return Ok(new { success = true, message = "Apartman başarıyla eklendi." });
                }
                else
                {
                    await _apartmanRepo.UpdateAsync(model);
                    return Ok(new { success = true, message = "Apartman başarıyla güncellendi." });
                }
            }
            return BadRequest(new { success = false, message = "Apartman bilgileri geçersiz." });
        }

        public async Task<IActionResult> ApartmanDetay(int apartmanId)
        {
            if (apartmanId == 0)
            {
                return NotFound();
            }
            var apartman = await _apartmanRepo.GetByIdAsync(apartmanId);
            if (apartman == null)
            {
                return NotFound();
            }
            var daireler = await _daireRepo.Query().Where(d => d.ApartmanId == apartmanId).ToListAsync();
            var site = await _siteRepo.GetByIdAsync(apartman.SiteId);
            var viewModel = new ApartmanDetayViewModel
            {
                Apartman = apartman,
                Site = site,
                Daireler = daireler

            };
            return View(viewModel);
        }

        public async Task<IActionResult> Sil(int apartmanId)
        {
            if (apartmanId < 1)
            {
                BadRequest(new { success = false, message = "Apartman bilgileri geçersiz." });
            }
            await _apartmanRepo.DeleteAsync(apartmanId);
            return Ok(new { success = false, message = "Apartman silindi." });
        }

        [HttpGet]
        public IActionResult ApartmanListesi()
        {
            var apartmanList = _apartmanRepo.Query()
                .Select(a => new { id = a.Id, ad = a.Ad})
                .OrderBy(a => a.ad)
                .ToList();
            return Json(apartmanList);
        }
    }
}
