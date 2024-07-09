using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using X.PagedList;

namespace MvcCamp.Controllers
{
    [Authorize]
    public class WriterPanelController : Controller
    {
        HeadingManager hm = new HeadingManager(new EfHeadingDal(new Context()));
        WriterManager wm = new WriterManager(new EfWriterDal(new Context()));
        CategoryManager cm = new CategoryManager(new EfCategoryDal(new Context()));
        ContentManager contentm = new ContentManager(new EfContentDal(new Context()));
        WriterValidatior writerValidatior = new WriterValidatior();
        Context context = new Context();
        [HttpGet]
        public IActionResult WriterProfile(int id)
        {
            string userEmail = User.Identity.Name;
           
            id= context.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = wm.GetByID(id);
          
            return View(writerValue);
        }
        [HttpPost]
        public IActionResult WriterProfile(Writer p)
        {
            var result = writerValidatior.Validate(p);
            if (result.IsValid)
            {
                wm.WriterUpdate(p);
                return RedirectToAction("AllHeading");
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
            List<SelectListItem> valueWriter = (from x in wm.GetList()
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
        public IActionResult AllHeading(int p = 1)
        {
            if (p < 1) p = 1;  // Ensure the page number is at least 1
            var headings = hm.GetList().ToPagedList(p, 4);
            return View((X.PagedList.IPagedList<Heading>)headings); // Cast to IPagedList
        }


    }
}
