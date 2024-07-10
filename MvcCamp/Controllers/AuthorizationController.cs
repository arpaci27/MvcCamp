using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
