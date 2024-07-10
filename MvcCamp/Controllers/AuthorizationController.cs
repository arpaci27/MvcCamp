using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adM = new AdminManager(new EfAdminDal(new Context()));
        public ActionResult Index()
        {
            var adminValues = adM.GetList();    
            return View(adminValues);
        }
    }
}
