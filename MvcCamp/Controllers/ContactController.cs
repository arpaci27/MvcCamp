using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class ContactController : Controller
    {
        ContactManager _contactmanager = new ContactManager(new EfContactDal(new Context()));
        ContactValidator _contactValidator = new ContactValidator();
        public IActionResult Index()
        {
            var contactvalues = _contactmanager.GetList();
            return View(contactvalues);
        }
        public PartialViewResult MessageSideMenu()
        {
               return PartialView();
        
        }

        public IActionResult GetContactDetails(int id)
        {
            var contactvalues = _contactmanager.GetByID(id);
            return View(contactvalues);
        }
    }
}
