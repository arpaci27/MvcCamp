using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
