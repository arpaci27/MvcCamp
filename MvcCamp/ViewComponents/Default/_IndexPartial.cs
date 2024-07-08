using Microsoft.AspNetCore.Mvc;

namespace MvcCamp.ViewComponents.Default
{
    public class _IndexPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
