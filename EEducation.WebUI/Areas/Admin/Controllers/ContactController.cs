using EEducation.Core.Service;
using EEducation.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EEducation.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ContactController : Controller
    {

        private readonly IDbService<Contact> _dbService;

        public ContactController(IDbService<Contact> dbService)
        {
            _dbService = dbService;
        }

        public IActionResult Index()
        {
            ViewBag.ErrorContact = "VERİ BULUNAMADI!";
            return View(_dbService.GetAll());

        }

        public IActionResult Update(int id)
        {
            return View(_dbService.GetById(id));
        }

        [HttpPost]
        public IActionResult Update(Contact contact)
        {
            if (contact.Adress != null && contact.Mail != null)
            {
                return _dbService.Update(contact) ? RedirectToAction("Index") : View();
            }
            ViewBag.ErrorUpdateContact = "HATA! Lütfen boş alan bırakmayınız..";
            return View();
        }
    }
}
