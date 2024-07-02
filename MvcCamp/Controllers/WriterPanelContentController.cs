using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MvcCamp.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager cm = new ContentManager(new EfContentDal(new Context()));
        Context context = new Context();

            public IActionResult MyContent()
            {
                string userEmail = User.Identity.Name;
                ViewBag.WelcomeMessage = $"Hoşgeldiniz, {userEmail}";

                var writerIdInfo = context.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterID).FirstOrDefault();
                var contentValues = cm.GetListByWriter(writerIdInfo);
                return View(contentValues);
            }
    }
}