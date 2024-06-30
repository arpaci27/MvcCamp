using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal(new Context()));
        public IActionResult MyContent()
        {
            var contentValues = cm.GetListByWriter();

            return View(contentValues);
        }
    }
}
