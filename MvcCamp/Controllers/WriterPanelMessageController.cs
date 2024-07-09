using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
    public class WriterPanelMessageController : Controller
    {
        MessageManager messageMenager = new MessageManager(new EfMessageDal(new Context()));
        MessageValidator messageValidator = new MessageValidator();
        Context context = new Context();
        [Authorize]
        public IActionResult Inbox()
        {
            string userEmail = User.Identity.Name;
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterID).FirstOrDefault();
            var messagelist = messageMenager.GetListInbox(userEmail);
            ViewBag.UnreadCount = messagelist.Count(m => m.Unread);
            return View(messagelist);
        }
        public IActionResult Sendbox()
        {
            string userEmail = User.Identity.Name;
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterID).FirstOrDefault();
            var messagelist = messageMenager.GetListSendbox(userEmail);
            return View(messagelist);
        }

        public PartialViewResult MessageSideMenu()
        {

        return PartialView(); 
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
            string userEmail = User.Identity.Name;
            var writerIdInfo = context.Writers.Where(x => x.WriterMail == userEmail).Select(y => y.WriterID).FirstOrDefault();
            p.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            var result = messageValidator.Validate(p);
            if (result.IsValid)
            {
                p.SenderMail = userEmail;
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
    }
}
