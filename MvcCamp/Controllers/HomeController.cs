using Microsoft.AspNetCore.Mvc;
using MvcCamp.Models;
using System.Diagnostics;

namespace MvcCamp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

       

        public IActionResult HomePage()
        {
            return View();
        }
    }
}
