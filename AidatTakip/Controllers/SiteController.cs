using AidatTakip.Data.Abstract;
using AidatTakip.Data.Concrete.Entities;
using AidatTakip.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace AidatTakip.Controllers
{
    public class SiteController : Controller
    {
        private readonly ISiteRepository _siteRepo;
        private readonly IApartmanRepository _apartmanRepo;
        private bool isYeniKayıt = false;
        public SiteController(ISiteRepository siteRepo, IApartmanRepository apartmanRepo)
        {
            _siteRepo = siteRepo;
            _apartmanRepo = apartmanRepo;
        }
        public IActionResult Index()
        {
            var sites = _siteRepo.Query()
                .Include(s => s.Apartmanlar)
                .ToList();
            return View(sites);
        }

        [HttpGet]
        public IActionResult SiteListesi()
        {
            var siteList = _siteRepo.Query()
                .Select(s => new { id = s.Id, ad = s.Ad })
                .OrderBy(s => s.ad)
                .ToList();
            return Json(siteList);
        }


        [HttpPost]
        public async Task<IActionResult> Ekle(Site site)
        {
            if(site.Id == 0)
            {
                isYeniKayıt = true;
            }
            if(isYeniKayıt)
            {
                await _siteRepo.AddAsync(site);
                return Ok();
            }
            else
            {
                await _siteRepo.UpdateAsync(site);
                return Ok();
            }
        }

        public async Task<IActionResult> SiteDetay(int siteId)
        {
            if(siteId == 0)
            {
                return NotFound();
            }
            var site = await _siteRepo.GetByIdAsync(siteId);
            var apartmanlar = await _apartmanRepo.Query()
                .Where(a => a.SiteId == siteId)
                .ToListAsync();
            if (site == null)
            {
                return NotFound();
            }
            var viewModel = new SiteDetayViewModel
            {
                site = site,
                apartmanlar = apartmanlar
            };
            return View(viewModel);
        }

        public async Task<IActionResult> Sil(int siteId)
        {
            if (siteId == 0)
            {
                return NotFound();
            }
            await _siteRepo.DeleteAsync(siteId);
            return Ok(new { message = "Site silindi" });
        }
    }
}
