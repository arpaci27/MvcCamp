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
            var messagelist = messageMenager.GetList();
            return View(messagelist);
        }
    }
}
