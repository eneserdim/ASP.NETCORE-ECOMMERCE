using EEducation.Core.Service;
using EEducation.Model.Context;
using EEducation.Model.Entities;
using EEducation.Service.DbService;
using Microsoft.AspNetCore.Mvc;

namespace EEducation.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {

        private readonly IDbService<Category> _db;

        public CategoryController(IDbService<Category> db)
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
        public IActionResult Add(Category category, IFormFile? file, IFormFile? file2)
        {

            if (file != null && file.Length > 0 && file2 != null && file2.Length > 0)
            {
                //Resim Ekleme Kısmı
                var filename = Path.GetFileName(file.FileName); // Dosyanın adını Path sınıfı üzerinden dosyanın adını aldık,
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);

                var filename2 = Path.GetFileName(file2.FileName); // Dosyanın adını Path sınıfı üzerinden dosyanın adını aldık,
                var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename2);

                //using içerisinde yazılı olan kodu yaptıktan sonra ilgili nesneyi bellekten otomatik bir şekilde uçsun istiyorsak using'i bu şekilde kullanabiliriz.
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream); // Parametre içerisinde gelen resmi CopyTo metodunu kullanarak stream nesnesi içerisindeki belirtilen path'e kopyalıyoruz.
                }

                using (var stream = new FileStream(filePath2, FileMode.Create))
                {
                    file2.CopyTo(stream); // Parametre içerisinde gelen resmi CopyTo metodunu kullanarak stream nesnesi içerisindeki belirtilen path'e kopyalıyoruz.
                }

                // Ürünler Tablosuna Ekleme

                category.CategoryImage = filename; //Resmin adını modele ekledik
                category.CategoryIcon = filename2; //Resmin adını modele ekledik

                return _db.Add(category) ? RedirectToAction("Index") : View();

            }
            ViewBag.CategoryAddError = "Bütün alanları eksiksiz doldurmalısınız.";
            return View();
        }


        // Güncelleme sayfasını gösterir
        public IActionResult Update(int id)
        {
            return View(_db.GetById(id));
        }

        // Güncelleme işlemini yapar
        [HttpPost]
        public IActionResult Update(Category category, IFormFile file, IFormFile? file2)
        {
            if (file != null && file.Length > 0 && file2 != null && file2.Length > 0)
            {
                //Resim Ekleme Kısmı
                var filename = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);

                var filename2 = Path.GetFileName(file2.FileName); 
                var filePath2 = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename2);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream); 
                }

                using (var stream = new FileStream(filePath2, FileMode.Create))
                {
                    file2.CopyTo(stream);
                }


                category.CategoryImage = filename; 
                category.CategoryIcon = filename2;

                return _db.Update(category) ? RedirectToAction("Index") : View();

            }
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

    }
}
