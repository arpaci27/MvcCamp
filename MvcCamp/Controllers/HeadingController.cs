using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal(new Context()));

        public IActionResult Index()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public IActionResult AddHeading()
        {
            
            return View();
        }
        [HttpPost]  
        public IActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
    }
}
