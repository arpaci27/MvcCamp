using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace MvcCamp.Controllers
{
    public class ErrorPagerController : Controller
    {
        public IActionResult Page403()
        {
            Response.StatusCode = 403;
            Response.Headers.Add("X-Custom-Error", "false");

            return View();
        }
        public IActionResult Page404()
        {
            Response.StatusCode = 404;
            Response.Headers.Add("X-Custom-Error", "false");

            return View();
        }
    }
}
