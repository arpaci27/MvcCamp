using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class WriterController : Controller
    {
        WriterManager WriterManager = new WriterManager(new EfWriterDal(new Context()));
        public IActionResult Index()
        {
            var writerValues = WriterManager.GetList();
            return View(writerValues);
        }

        [HttpGet]
        public IActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddWriter(Writer p)
        {
            WriterManager.WriterAdd(p);
            return RedirectToAction("Index");
        }
    }
}
