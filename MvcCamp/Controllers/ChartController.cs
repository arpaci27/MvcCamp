using Microsoft.AspNetCore.Mvc;
using MvcCamp.Models;
using System.Collections.Generic;

namespace MvcCamp.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CategoryChart()
        {
            return Json(BlogList());
        }

        private List<CategoryClass> BlogList()
        {
            var categoryClass = new List<CategoryClass>
            {
                new CategoryClass { CategoryName = "Yazılım", CategoryCount = 8 },
                new CategoryClass { CategoryName = "Seyahat", CategoryCount = 4 },
                new CategoryClass { CategoryName = "Teknoloji", CategoryCount = 6 }
            };
            return categoryClass;
        }
    }
}