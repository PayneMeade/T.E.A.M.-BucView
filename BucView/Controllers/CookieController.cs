using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace BucView.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            if (!HttpContext.Request.Cookies.ContainsKey("page"))
            {
                CookieOptions options = new CookieOptions();
                options.Expires = DateTimeOffset.Now.AddDays(7);

                HttpContext.Response.Cookies.Append("tour", "WebPage");
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
