using EEducation.Core.Service;
using EEducation.Model.Entities;
using Microsoft.AspNetCore.Mvc;
using System.Drawing.Drawing2D;

namespace EEducation.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AboutController : Controller
    {
        private readonly IDbService<About> _dbAbout;
        private readonly IDbService<OurTeam> _dbTeam;
        private readonly IDbService<Brand> _dbBrand;

        public AboutController(IDbService<About> dbAbout, IDbService<OurTeam> dbTeam, IDbService<Brand> dbBrand)
        {
            _dbAbout = dbAbout;
            _dbTeam = dbTeam;
            _dbBrand = dbBrand;
        }

        public IActionResult Index()
        {
            return View(_dbAbout.GetAll());
        }


        // HAKKIMIZDA İŞLEMLERİ

        public IActionResult UpdateAbout(int id) 
        { 
            return View(_dbAbout.GetById(id));
        }

        [HttpPost]
        public IActionResult UpdateAbout(About about, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filename = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                about.AboutPhoto = filename;
                return _dbAbout.Update(about) ? RedirectToAction("Index") : View();
            }
            ViewBag.AboutError = "HATA! Lütfen Tekrar Deneyiniz.";
            return View();
        }


        // EKİBİMİZ İŞLEMLERİ

        public IActionResult OurTeamList()
        {
            return View(_dbTeam.GetAll()); 
        }

        public IActionResult AddOurTeam()
        { 
            return View(); 
        }

        [HttpPost]
        public IActionResult AddOurTeam(OurTeam ourTeam, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filename = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                ourTeam.PersonalImage = filename;

                return _dbTeam.Add(ourTeam) ? RedirectToAction("OurTeamList") : View();
            }
            ViewBag.TeamAddError = "HATA! Lütfe Tekrar Deneyiniz.";
            return View();
        }


        public IActionResult UpdateOurTeam(int id)
        {
            return View(_dbTeam.GetById(id));
        }

        [HttpPost]
        public IActionResult UpdateOurTeam(OurTeam ourTeam, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filename = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                ourTeam.PersonalImage = filename;
                return _dbTeam.Update(ourTeam) ? RedirectToAction("OurTeamList") : View();
            }
            ViewBag.AboutError = "HATA! Lütfen Tekrar Deneyiniz.";
            return View();
        }

        public IActionResult DeleteOurTeam(int id)
        {
            if (id > 0)
            {
                return _dbTeam.Delete(_dbTeam.GetById(id)) ? RedirectToAction("OurTeamList") : View();
            }

            return View();
        }

        // MARKALARIMIZ İŞLEMLERİ

        public IActionResult BrandList()
        { 
            return View(_dbBrand.GetAll()); 
        }

        public IActionResult AddBrand()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddBrand(Brand brand, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filename = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                brand.BrandLogo = filename;

                return _dbBrand.Add(brand) ? RedirectToAction("BrandList") : View();
            }
            ViewBag.TeamAddError = "HATA! Lütfen Tekrar Deneyiniz.";
            return View();
        }

        public IActionResult UpdateBrand(int id)
        {
            return View(_dbBrand.GetById(id));
        }

        [HttpPost]
        public IActionResult UpdateBrand(Brand brand, IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var filename = Path.GetFileName(file.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", filename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                brand.BrandLogo = filename;
                return _dbBrand.Update(brand) ? RedirectToAction("BrandList") : View();
            }
            ViewBag.AboutError = "HATA! Lütfen Tekrar Deneyiniz.";
            return View();
        }

        public IActionResult DeleteBrand(int id)
        {
            if (id > 0)
            {
                return _dbBrand.Delete(_dbBrand.GetById(id)) ? RedirectToAction("BrandList") : View();
            }

            return View();
        }

    }
}
