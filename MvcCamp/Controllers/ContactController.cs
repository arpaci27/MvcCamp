using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
