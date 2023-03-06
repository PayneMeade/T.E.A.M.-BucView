using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;

namespace BucView.Controllers
{
    public class TourController : Controller
    {

        public IActionResult Index(string id)
        {
            if (id != null)
            {
                var parsedString = HttpUtility.UrlDecode(id);
                ViewData["Building"] = parsedString;
            }
            else
            {
                ViewData["Building"] = "N/A";
            }
            return View();
        }
    }
}
