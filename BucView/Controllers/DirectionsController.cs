using Microsoft.AspNetCore.Mvc;

namespace BucView.Controllers
{
    public class DirectionsController : Controller
    {
        public IActionResult Index(string fromBuilding, string toBuilding)
        {
            if (!string.IsNullOrEmpty(fromBuilding) && !string.IsNullOrEmpty(toBuilding))
            {
                ViewData["FromBuilding"] = fromBuilding;
                ViewData["ToBuilding"] = toBuilding;
            }
            else
            {
                ViewData["FromBuilding"] = "N/A";
                ViewData["ToBuilding"] = "N/A";
            }
            return View();
        }
    }
}
