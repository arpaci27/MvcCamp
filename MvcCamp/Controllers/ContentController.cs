using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class ContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal(new Context()));
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult GetAllContent(string p)
        {
            if (p == null)
            {
                var values = cm.GetList(p);
                return View(values);
            }
            else { 
            var values = cm.GetListBySearch(p);
                return View(values);
            }
           
        }
        public IActionResult ContentByHeading(int id)
        {
            var contentValues = cm.GetListByHeadingId(id);
          
            return View(contentValues);
        }
    }
}
