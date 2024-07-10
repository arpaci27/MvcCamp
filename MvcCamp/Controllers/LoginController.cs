using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PaulMiami.AspNetCore.Mvc.Recaptcha;
using System.Security.Claims;

namespace MvcCamp.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager WriterLoginManager = new WriterLoginManager(new EfWriterDal(new Context()));
        public string[] GetRolesForUser(string identifier, string userType)
        {
            using (var context = new Context())
            {
                if (userType == "admin")
                {
                    var admin = context.Admins.FirstOrDefault(x => x.AdminUserName == identifier);
                    if (admin != null)
                    {
                        return new string[] { admin.AdminRole };
                    }
                }
                return new string[0];
            }
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Admin p)
        {
            

            Context c = new Context();
            var adminUserInfo = c.Admins.FirstOrDefault(x => x.AdminUserName == p.AdminUserName && x.AdminPassword == p.AdminPassword);
            if (adminUserInfo != null)
            {
                var roles = GetRolesForUser(adminUserInfo.AdminUserName, "admin");
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, adminUserInfo.AdminUserName)
        };

                foreach (var role in roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false,
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlış.";
                return View();
            }
        }


        [HttpGet]
        public IActionResult WriterLogin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> WriterLogin(Writer p)
        {
            ////Context c = new Context();
            //////var writerUserInfo = c.Writers.FirstOrDefault(x => x.WriterMail == p.WriterMail && x.WriterPassword == p.WriterPassword);
            var writerUserInfo = WriterLoginManager.GetWriter(p.WriterMail, p.WriterPassword);
            if (writerUserInfo != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, writerUserInfo.WriterMail),
                    new Claim(ClaimTypes.NameIdentifier, writerUserInfo.WriterID.ToString())
                };

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = false,
                };
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                ViewBag.ErrorMessage = "Kullanıcı adı veya şifre yanlış.";
                return View();
            }
        }
        public IActionResult LogOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Headings", "Default");
        }
    }
}