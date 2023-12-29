using EEducation.Core.Service;
using EEducation.Model.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Drawing;

namespace EEducation.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        // DB işlemleri için nesne örneğine ihtiyaç var

        private readonly IDbService<Product> _db;
        private readonly IDbService<Category> _dbCategory;

        public ProductController(IDbService<Product> db, IDbService<Category> dbCategory)
        {
            _db = db;
            _dbCategory = dbCategory;
        }

        //Listele
        public IActionResult Index()
        {
            ViewBag.KategoriListesi = _dbCategory.GetAll();
            return View(_db.GetAll());
        }

        public IActionResult Add()
        {
            ViewBag.KategoriListesi = _dbCategory.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product p, IFormFile? file)
        {

            if (file != null && file.Length > 0)
            {
                //Resim Ekleme Kısmı
                var filename = Path.GetFileName(file.FileName); // Dosyanın adını Path sınıfı üzerinden dosyanın adını aldık,
                var filePath = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot","images",filename);


                //using içerisinde yazılı olan kodu yaptıktan sonra ilgili nesneyi bellekten otomatik bir şekilde uçsun istiyorsak using'i bu şekilde kullanabiliriz.
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream); // Parametre içerisinde gelen resmi CopyTo metodunu kullanarak stream nesnesi içerisindeki belirtilen path'e kopyalıyoruz.
                }

                // Ürünler Tablosuna Ekleme

                p.ProductImageName = filename; //Resmin adını modele ekledik
                return _db.Add(p) ? RedirectToAction("Index") : View();

            }
            ViewBag.ProductAddError = "Bütün alanları eksiksiz doldurmalısınız.";
            return View();
        }


        // Güncelleme sayfasını gösterir
        public IActionResult Update(int id)
        {
            ViewBag.KategoriListesi = _dbCategory.GetAll();
            return View(_db.GetById(id));
        }

        // Güncelleme işlemini yapar
        [HttpPost]
        public IActionResult Update(Product p, IFormFile file)
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
                    p.ProductImageName = filename; // Resmin adını modele ekledik

                    return _db.Update(p) ? RedirectToAction("Index") : View();
  
                }

                ViewBag.ProductUpdateError = "Bütün alanları eksiksiz doldurmalısınız";
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
