using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcCamp.Controllers
{
    public class HeadingController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal(new Context()));
        CategoryManager cm = new CategoryManager(new EfCategoryDal(new Context()));
        WriterManager WriterManager = new WriterManager(new EfWriterDal(new Context()));
        public IActionResult Index()
        {
            var headingValues = hm.GetList();
            return View(headingValues);
        }
        [HttpGet]
        public IActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            List<SelectListItem> valueWriter = (from x in WriterManager.GetList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurName,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlc = valueCategory;
            ViewBag.vlw = valueWriter;
            return View();
        }
        [HttpPost]  
        public IActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            hm.HeadingAdd(heading);
            return RedirectToAction("Index");
        }
        [HttpGet]
       public IActionResult EditHeading(int id )
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = hm.GetByID(id);
            return View(headingValue);
        }

        [HttpPost]
        public IActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            hm.HeadingDelete(headingValue);
            return RedirectToAction("Index");
        }
    }
}
