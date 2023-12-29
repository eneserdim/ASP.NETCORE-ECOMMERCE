using EEducation.Core.Service;
using EEducation.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EEducation.WebUI.ViewComponents
{
    public class AllCategoryMenu : ViewComponent
    {
        private readonly IDbService<Category> _db;

        public AllCategoryMenu(IDbService<Category> db)
        {
            _db = db;
        }

        public IViewComponentResult Invoke()
        {
            return View(_db.GetAll());
        }


    }
}
