using EEducation.Core.Service;
using EEducation.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EEducation.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IDbService<Product> _db;
        private readonly IDbService<Category> _dbCategory;
        public CategoryController(IDbService<Product> db, IDbService<Category> dbCategory)
        {
            _db = db;
            _dbCategory = dbCategory;
        }

        public IActionResult Products(int id)
        {
            ViewBag.CategoryList = _dbCategory.GetAll();
            return View(_db.GetAll().Where(x => x.CategoryId == id).ToList());
        }

        public IActionResult _CategoryPartial()
        { 
            return PartialView(_dbCategory.GetAll());
        }
    }
}
