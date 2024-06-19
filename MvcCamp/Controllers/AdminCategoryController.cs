using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class AdminCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
