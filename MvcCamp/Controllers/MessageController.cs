using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageMenager = new MessageManager(new EfMessageDal(new Context()));
        public IActionResult Inbox()
        {
            var messagelist = messageMenager.GetListInbox();
            return View(messagelist);
        }
        public IActionResult Sendbox()
        {
            var messagelist = messageMenager.GetListSendbox();
            return View(messagelist);
        }
        public IActionResult GetInboxMessageDetails(int id)
        {
            var inboxMessageValues = messageMenager.GetByID(id);
            return View(inboxMessageValues);
        }
        [HttpGet]
        public IActionResult NewMessage()
        {
           return View();
        }
        [HttpPost]
        public IActionResult NewMessage(Message p)
        {
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            messageMenager.MessageAdd(p);
            return RedirectToAction("Sendbox");
        }
    }
}
