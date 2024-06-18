using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
