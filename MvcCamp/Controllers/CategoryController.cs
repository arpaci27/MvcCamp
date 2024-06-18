using BusinessLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager cm = new CategoryManager(new EF);
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCategoryList()
        {
            //var categoryValues = cm.GetAllBl(); 
            return View();
        }
        [HttpGet]


        public IActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddCategory(Category p)
        {
            //cm.CategoryAddBl(p);

            return RedirectToAction("GetCategoryList");
        }
    }
}
