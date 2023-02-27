using Microsoft.AspNetCore.Mvc;

namespace BucView.Controllers
{
    public class TourController : Controller
    {
        public IActionResult Index(string id)
        {
            if (id != null)
                ViewData["Building"] = id;
            else
                ViewData["Building"] = "N/A";
            return View();
        }
    }
}
