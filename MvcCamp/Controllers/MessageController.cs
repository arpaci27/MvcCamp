using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class MessageController : Controller
    {
        MessageManager messageMenager = new MessageManager(new EfMessageDal(new Context()));
        MessageValidator messageValidator = new MessageValidator();
        [Authorize]
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
        public IActionResult GetInboxMessageDetails(int id)
        {
            var inboxMessageValues = messageMenager.GetByID(id);
            if (inboxMessageValues != null && inboxMessageValues.Unread)
            {
                messageMenager.MarkAsRead(id);
            }
            return View(inboxMessageValues);
        }
        public IActionResult GetSendboxMessageDetails(int id)
        {
            var sendboxValues = messageMenager.GetByID(id);
            return View(sendboxValues);
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
            var result = messageValidator.Validate(p);
            if (result.IsValid)
            {
                p.SenderMail = "admin@gmail.com";
                messageMenager.MessageAdd(p);
                return RedirectToAction("Sendbox");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();

        }
        [HttpPost]
        public IActionResult MarkAsRead(int id)
        {
            messageMenager.MarkAsRead(id);
            return Ok();
        }
    }
}
