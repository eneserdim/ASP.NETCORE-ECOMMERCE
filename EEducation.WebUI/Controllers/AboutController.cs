using EEducation.Core.Service;
using EEducation.Model.Entities;
using EEducation.Service.DbService;
using Microsoft.AspNetCore.Mvc;

namespace EEducation.WebUI.Controllers
{
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
            ViewBag.TeamList = _dbTeam.GetAll();
            ViewBag.BrandList = _dbBrand.GetAll();
            return View(_dbAbout.GetAll());
        }
    }
}
