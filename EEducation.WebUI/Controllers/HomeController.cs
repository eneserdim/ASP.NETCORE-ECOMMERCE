using EEducation.Core.Service;
using EEducation.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EEducation.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbService<Product> _dbProduct;
        private readonly IDbService<Category> _dbCategory;
        private readonly IDbService<Slider> _dbSlider;

        public HomeController(IDbService<Product> dbProduct, IDbService<Category> dbCategory, IDbService<Slider> dbSlider)
        {
            _dbProduct = dbProduct;
            _dbCategory = dbCategory;
            _dbSlider = dbSlider;   
        }

        public IActionResult Index()
        {
            ViewBag.CategoryList = _dbCategory.GetAll();
            ViewBag.ProductList = _dbProduct.GetAll();
            return View(_dbSlider.GetAll());
        }
    }
}
