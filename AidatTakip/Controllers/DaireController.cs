using AidatTakip.Data.Abstract;
using AidatTakip.Data.Concrete.Entities;
using Microsoft.AspNetCore.Mvc;

namespace AidatTakip.Controllers
{
    public class DaireController : Controller
    {
        private readonly IDaireRepository _daireRepo;
        public DaireController(IDaireRepository daireRepo)
        {
            _daireRepo = daireRepo;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Ekle(Daire daire, IFormFile filePath)
        {
            if (filePath != null && filePath.Length > 0)
            {
                var fileName = Path.GetFileName(filePath.FileName);
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(fileName);
                var uploads = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/daireSorumlulari");
                var filePathFull = Path.Combine(uploads, uniqueFileName);

                // Klasör yoksa oluştur
                if (!Directory.Exists(uploads))
                    Directory.CreateDirectory(uploads);

                using (var stream = new FileStream(filePathFull, FileMode.Create))
                {
                    await filePath.CopyToAsync(stream);
                }

                daire.SorumluImage = "/images/daireSorumlulari/" + uniqueFileName;
            }
            if (daire.Id == 0)
            {
                await _daireRepo.AddAsync(daire);

                return Ok(new { success = true, message = "Daire başarıyla eklendi." });
            }
            else
            {
                await _daireRepo.UpdateAsync(daire);
                return Ok(new { success = true, message = "Daire başarıyla güncellendi." });
            }

        }

        public async Task<IActionResult> Sil(int daireId)
        {
            if(daireId <= 0)
            {
                return BadRequest(new { success = false, message = "Geçersiz daire ID." });
            }
            await _daireRepo.DeleteAsync(daireId);
            return Ok(new { success = true, message = "Daire başarıyla silindi." });
        }

    }
}
