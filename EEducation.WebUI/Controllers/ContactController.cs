using EEducation.Core.Entity;
using EEducation.Core.Service;
using EEducation.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EEducation.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IDbService<Contact> _dbService;

        public ContactController(IDbService<Contact> dbService)
        {
            _dbService = dbService;
        }

        public IActionResult Index()
        {

            return View(_dbService.GetAll());
        }
    }
}
