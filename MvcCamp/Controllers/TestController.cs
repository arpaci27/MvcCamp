using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SweetAlert()
        {
            return View();
        }
    }
}
