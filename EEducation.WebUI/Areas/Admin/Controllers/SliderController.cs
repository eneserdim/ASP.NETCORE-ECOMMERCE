using EEducation.Core.Service;
using EEducation.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EEducation.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {

        // DB işlemleri için nesne örneğine ihtiyaç var

        private readonly IDbService<Slider> _db;

        public SliderController(IDbService<Slider> db)
        {
            _db = db;
        }

        //Listele
        public IActionResult Index()
        {
            return View(_db.GetAll());
        }

        public IActionResult Add()
        {
            return View();
            
        }

        [HttpPost]
        public IActionResult Add(Slider slider, IFormFile? file)
        {

            if (file != null && file.Length > 0)
            {
                //Resim Ekleme Kısmı
                var filename = Path.GetFileName(file.FileName); // Dosyanın adını Path sınıfı üzerinden dosyanın adını aldık,
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);


                //using içerisinde yazılı olan kodu yaptıktan sonra ilgili nesneyi bellekten otomatik bir şekilde uçsun istiyorsak using'i bu şekilde kullanabiliriz.
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream); // Parametre içerisinde gelen resmi CopyTo metodunu kullanarak stream nesnesi içerisindeki belirtilen path'e kopyalıyoruz.
                }

                // Ürünler Tablosuna Ekleme

                slider.SliderImage = filename; //Resmin adını modele ekledik
                return _db.Add(slider) ? RedirectToAction("Index") : View();

            }
            ViewBag.ProductAddError = "Bütün alanları eksiksiz doldurmalısınız.";
            return View();
        }


        // Güncelleme sayfasını gösterir
        public IActionResult Update(int id)
        {
            return View(_db.GetById(id));
        }

        // Güncelleme işlemini yapar
        [HttpPost]
        public IActionResult Update(Slider slider, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                // Resim Ekleme Kısmı
                var filename = Path.GetFileName(file.FileName); // Dosyanın adını Path sınıfı üzerinden dosyanın adını aldık
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);

                // using içerisinde yazılı olan kodu yaptıktan sonra ilgili nesneyi bellekten otomatik bir şekilde uçsun istiyorsak usign'i bu şekilde de kullanabiliriz
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream); // Parametre içerisinde gelen resmi CopyTo metodunu kullanarak stream nesnesi içerisindeli belirtilen path'e kopyalıyoruz(kayderiyoruz)
                }

                // Ürünler tablosuna ekleme yap
                slider.SliderImage = filename; // Resmin adını modele ekledik

                return _db.Update(slider) ? RedirectToAction("Index") : View();

            }

            ViewBag.SliderUpdateError = "Bütün alanları eksiksiz doldurmalısınız";
            return View();

        }

        public IActionResult Delete(int id)
        {
            if (id > 0)
            {
                return _db.Delete(_db.GetById(id)) ? RedirectToAction("Index") : View();
            }

            return View();
        }


        public IActionResult Test()
        {
            return View();
        }

    }
}
