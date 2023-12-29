using EEducation.Core.Service;
using EEducation.Model.Entities;
using Microsoft.AspNetCore.Mvc;


namespace EEducation.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDbService<Product> _db;
        private readonly IDbService<Category> _dbCategory;

        public ProductController(IDbService<Product> db, IDbService<Category> dbCategory)
        {
            _db = db;
            _dbCategory = dbCategory;
        }

        public IActionResult Index()
        {
            ViewBag.CategoryList = _dbCategory.GetAll();
            return View(_db.GetAll());
        }
        public IActionResult Detail(int id)
        {
            ViewBag.ProductList = _db.GetAll();
            return View(_db.GetById(id));
        }
    }
}
