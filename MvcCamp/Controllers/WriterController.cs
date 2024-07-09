using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class WriterController : Controller
    {
        WriterManager WriterManager = new WriterManager(new EfWriterDal(new Context()));
        WriterValidatior writerValidatior = new WriterValidatior();
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
            
            var result = writerValidatior.Validate(p);
            if (result.IsValid)
            {
                WriterManager.WriterAdd(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }
        }

        [HttpGet]
        public IActionResult EditWriter(int id)
        {
            var writerValue = WriterManager.GetByID(id);    
            return View(writerValue);
        }
        [HttpPost]
        public IActionResult EditWriter(Writer p)
        {
            var result = writerValidatior.Validate(p);
            if (result.IsValid)
            {
                WriterManager.WriterUpdate(p);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
                return View();
            }

        }
    }
}
