using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcCamp.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal(new Context()));
        WriterManager WriterManager = new WriterManager(new EfWriterDal(new Context()));
        CategoryManager cm = new CategoryManager(new EfCategoryDal(new Context()));
        ContentManager contentm = new ContentManager(new EfContentDal(new Context()));

        Context context = new Context();
        public IActionResult WriterProfile()
        {
            return View();
        }
        public IActionResult MyHeading(string p)
        {
            string userEmail = User.Identity.Name;
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterID).FirstOrDefault();

            // Assuming you have a method to get headings by writer
            var headingValues = hm.GetListByWriter(writerIdInfo);

            return View(headingValues);
        }
        [HttpGet]
        public IActionResult NewHeading()
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
        public IActionResult NewHeading(Heading heading)
        {
            string userEmail = User.Identity.Name; // Giriş yapmış kullanıcının e-postasını al

            // Yazarın ID'sini e-posta adresine göre veritabanından çek
            var writerId = context.Writers
                .Where(x => x.WriterMail == userEmail)
                .Select(y => y.WriterID)
                .FirstOrDefault();

            if (writerId == 0) // Eğer yazar bulunamazsa
            {
                // Hata işleme - örneğin bir hata sayfasına yönlendirme
                return RedirectToAction("Error", "Home");
            }

            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = writerId; // Dinamik olarak atanan WriterID
            heading.HeadingStatus = true;
            hm.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public IActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var headingValue = hm.GetListByWriter(id);
            return View(headingValue);
        }

        [HttpPost]
        public IActionResult EditHeading(Heading heading)
        {
            hm.HeadingUpdate(heading);
            return RedirectToAction("WriterProfile");
        }

        public IActionResult DeleteHeading(int id)
        {
            var headingValue = hm.GetByID(id);
            headingValue.HeadingStatus = false;
            hm.HeadingDelete(headingValue);
            return RedirectToAction("MyHeading");
        }
        public IActionResult AllHeading()
        {
            var headings = hm.GetList();
            return View(headings);
        }


    }
}
