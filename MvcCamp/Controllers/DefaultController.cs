using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace MvcCamp.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal(new Context()));
        ContentManager contentManager = new ContentManager(new EfContentDal(new Context()));

        public IActionResult Headings()
        {
            var headingList = headingManager.GetList();
            ViewBag.ContentList = contentManager.GetList(); // Store contentList in ViewBag
            return View(headingList);
        }

        public PartialViewResult Index()
        {
            var contentList = contentManager.GetList();
            return PartialView(contentList);
        }
    }
}