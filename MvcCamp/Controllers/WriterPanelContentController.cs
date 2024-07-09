using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MvcCamp.Controllers
{
    [Authorize]
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal(new Context()));
        Context context = new Context();

            public IActionResult MyContent()
            {
                string userEmail = User.Identity.Name;

                var writerIdInfo = context.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterID).FirstOrDefault();
                var contentValues = cm.GetListByWriter(writerIdInfo);
                return View(contentValues);
            }
        [HttpGet]
        public IActionResult AddContent(int id )
        {
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public IActionResult AddContent(Content content)
        {
            string userEmail = User.Identity.Name;

            var writerIdInfo = context.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate = System.DateTime.Parse(System.DateTime.Now.ToShortDateString());
            content.WriterID = writerIdInfo;
            content.ContetStatus = true;
            cm.ContentAdd(content);
            return RedirectToAction("MyContent");
        }
        public IActionResult ToDoList()
        {
            return View();
        }
    }
}