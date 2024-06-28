using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.Controllers
{
	public class LoginController : Controller
	{
		[HttpGet]
		public IActionResult Index()
		{
			return View();
		}

		[HttpPost]
		public IActionResult Index(Admin p)
		{
			Context c = new Context();
			var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
			if (adminUserInfo != null)
			{
				return RedirectToAction("Index", "AdminCategory");
			}
			else
			{
				ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlış.";
				return View();
			}
		}
	}
}
