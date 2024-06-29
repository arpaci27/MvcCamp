using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;


namespace MvcCamp.Controllers
{
    public class LoginController : Controller
    {
        public string[] GetRolesForUser(string username)
        {
            using (var context = new Context())
            {
                var admin = context.Admins.FirstOrDefault(x => x.AdminUserName == username);
                if (admin != null)
                {
                    return new string[] { admin.AdminRole };
                }
                // Add more role checks here if needed
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
                var roles = GetRolesForUser(adminUserInfo.AdminUserName);
                var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, adminUserInfo.AdminUserName)
        };

                // Add roles to claims
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
    }

}