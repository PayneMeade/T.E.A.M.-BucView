using Microsoft.AspNetCore.Mvc;

namespace BucView.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("page"))
            {
                HttpContext.Response.Cookies.Append("page", "WebPage");
                return View();
            }
            else
            {
                var page = HttpContext.Request.Cookies["page"];
                return View(page);
            }
        }
    }
}
