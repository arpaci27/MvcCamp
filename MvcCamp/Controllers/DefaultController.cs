using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;

namespace MvcCamp.Controllers
{
    [AllowAnonymous]
    [Route("Default")]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal(new Context()));
        ContentManager contentManager = new ContentManager(new EfContentDal(new Context()));

        [Route("Headings/{id?}")]
        public IActionResult Headings(int id = 0)
        {
            var headingList = headingManager.GetList();
            ViewBag.ContentList = id == 0 ? new List<EntityLayer.Concrete.Content>() : contentManager.GetListByHeadingId(id);
            ViewBag.SelectedHeadingId = id;
            return View(headingList);
        }

        public PartialViewResult Index(int id=0)
        {
            var contentList = contentManager.GetListByHeadingId(id);
            if (contentList == null || !contentList.Any())
            {
                // Eğer liste boşsa, boş bir liste gönderelim
                return PartialView(new List<EntityLayer.Concrete.Content>());
            }
            return PartialView(contentList);

        }

    }
}