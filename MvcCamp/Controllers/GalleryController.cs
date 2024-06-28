using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class GalleryController : Controller
    {
        ImageFileManager ImageFileManager = new ImageFileManager(new EfImageFileDal(new Context()));
        public IActionResult Index()
        {
            var files = ImageFileManager.GetList();
            return View(files);
        }
    }
}
