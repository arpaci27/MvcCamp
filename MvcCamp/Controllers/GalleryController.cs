using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class GalleryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
