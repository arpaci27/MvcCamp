using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageMenager = new MessageManager(new EfMessageDal(new Context()));
        MessageValidator messageValidator = new MessageValidator();
      
        public IActionResult Inbox()
        {
            var messagelist = messageMenager.GetListInbox();
            ViewBag.UnreadCount = messagelist.Count(m => m.Unread);
            return View(messagelist);
        }
        public IActionResult Sendbox()
        {
            var messagelist = messageMenager.GetListSendbox();
            return View(messagelist);
        }

        public PartialViewResult MessageSideMenu()
        {

        return PartialView(); 
        }
    }
}
