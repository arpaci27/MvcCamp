using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class DefaultController : Controller
    {
        HeadingManager headingManeger = new HeadingManager(new EfHeadingDal(new Context()));
        public IActionResult Headings()
        {
            var headingList = headingManeger.GetList();
           return View(headingList);
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
