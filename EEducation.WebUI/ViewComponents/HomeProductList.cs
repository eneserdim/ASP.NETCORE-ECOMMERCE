using EEducation.Core.Service;
using EEducation.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EEducation.WebUI.ViewComponents
{
    public class HomeProductList : ViewComponent
    {
        private readonly IDbService<Product> _dbProduct;

        public HomeProductList(IDbService<Product> dbProduct)
        {
            _dbProduct = dbProduct;
        }

        public IViewComponentResult Invoke()
        {
            return View(_dbProduct.GetAll());
        }

    }
}
