using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MvcCamp.Controllers
{
    [Authorize (Roles = "B")]
    public class AuthorizationController : Controller
    {
        AdminManager adM = new AdminManager(new EfAdminDal(new Context()));
        public ActionResult Index()
        {
            var adminValues = adM.GetList();    
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            adM.AdminAdd(p);
            return RedirectToAction("Index");
                
        }
        [HttpGet]
        public IActionResult EditAdmin(int id)
        {
            var roles = new List<SelectListItem>
    {
        new SelectListItem { Value = "A", Text = "A" },
        new SelectListItem { Value = "B", Text = "B" },
        new SelectListItem { Value = "C", Text = "C" }
    };

            ViewBag.Roles = roles;
            var adminValue = adM.GetByID(id);
            return View(adminValue);
        }

        [HttpPost]

        public IActionResult EditAdmin(Admin p)
        {
            adM.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}
