//using BusinessLayer.Concrete;
//using BusinessLayer.ValidationRules;
//using DataAccesLayer.Concrete;
//using DataAccesLayer.EntityFramework;
//using EntityLayer.Concrete;
//using FluentValidation.Results;
//using Microsoft.AspNetCore.Mvc;


//namespace MvcCamp.Controllers
//{
//    public class CategoryController : Controller
//    {
//        CategoryManager cm = new CategoryManager(new EfCategoryDal(new Context()));
//        public IActionResult Index()
//        {
//            return View();
//        }

//        public IActionResult GetCategoryList()
//        {
//            var categoryValues = cm.GetList(); 
//            return View(categoryValues);
//        }
//        [HttpGet]


//        public IActionResult AddCategory()
//        {
//            return View();
//        }

//        [HttpPost]
//        public IActionResult AddCategory(Category p)
//        {
//            CategoryValidation categoryValidation = new CategoryValidation();
//            ValidationResult results = categoryValidation.Validate(p);
//            if (results.IsValid)
//            {
//                cm.CategoryAdd(p);

//                return RedirectToAction("GetCategoryList");
//            }
//            else
//            {
//                foreach (var item in results.Errors)
//                {
//                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
//                }
//            }
//            return View();
//        }
//    }
//}
