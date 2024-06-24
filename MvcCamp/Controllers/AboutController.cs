using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal(new Context()));
        public IActionResult Index()
        {
            var values = aboutManager.GetList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddAbout()
        {   
            return View();
        }
        [HttpPost]
        public IActionResult AddAbout(About p)
        {
            aboutManager.AboutAdd(p);
            return RedirectToAction("Index");
        }
    }
}
