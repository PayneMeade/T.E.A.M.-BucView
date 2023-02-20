using Microsoft.AspNetCore.Mvc;

namespace BucView.Controllers
{
    public class TourController : Controller
    {
        public IActionResult Index(string building)
        {
            if (!string.IsNullOrEmpty(building))
                ViewData["Building"] = building;
            else
                ViewData["Building"] = "N/A";
            return View();
        }
    }
}
