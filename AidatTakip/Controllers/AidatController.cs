using AidatTakip.Data.Abstract;
using AidatTakip.Data.Concrete.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AidatTakip.Controllers
{
    public class AidatController : Controller
    {
        private readonly IAidatRepository _aidatRepo;
        private readonly IApartmanRepository _apartmanRepo;

        public AidatController(IAidatRepository aidatRepo, IApartmanRepository apartmanRepo)
        {
            _aidatRepo = aidatRepo;
            _apartmanRepo = apartmanRepo;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Ekle(Aidat model,int siteId)
        {
            var apartman = await _apartmanRepo.GetByIdAsync(siteId);
            if (apartman == null)
            {
                return BadRequest(new { success = false, message = "Geçersiz apartman seçimi." });
            }
            if (model.Id ==0)
            {
                foreach(var apart in apartman.Daireler)
                {

                }
               
                await _aidatRepo.AddAsync(model);
                return Ok(new { success = true, message = "Aidat başarıyla eklendi." });
            }
            else
            {
                await _aidatRepo.UpdateAsync(model);
                return Ok(new { success = true, message = "Aidat başarıyla güncellendi." });
            }

        }


    }
}
