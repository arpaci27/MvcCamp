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
        Context _context = new Context();

        public ContactController(Context context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var contactvalues = _contactmanager.GetList();
            return View(contactvalues);
        }
        private int GetUnreadMessageCount()
        {
            // Replace 'Messages' with your actual DbSet name if different
            int count = _context.Messages.Count(m => m.Unread);
            Console.WriteLine($"Unread Message Count: {count}"); // Or use a logging framework
            return count;
        }



        public PartialViewResult MessageSideMenu()
        {
            int unreadMessageCount = GetUnreadMessageCount();
            ViewBag.UnreadMessageCount = unreadMessageCount;
            return PartialView();
        
        }
        
        public IActionResult GetContactDetails(int id)
        {
            var contactvalues = _contactmanager.GetByID(id);
            return View(contactvalues);
        }
    }
}
