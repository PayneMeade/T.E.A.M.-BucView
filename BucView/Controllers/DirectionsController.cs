using Microsoft.AspNetCore.Mvc;
using BucView.Models;
namespace BucView.Controllers

{
    public class DirectionsController : Controller
    {
        public IActionResult Index(string id, string toBuilding)
        {
            var tour1 = new Tour1();
            if (id == null)
            {
                toBuilding = tour1.getNext("");
            }
            else
            {
                toBuilding = tour1.getNext(id);
            }
            if (id == null)
            {
                ViewData["FromBuilding"] = "N/A";
            }
            else
            {
                ViewData["FromBuilding"] = id;
            }
            if (toBuilding == null)
            {
                ViewData["ToBuilding"] = "N/A";
            }
            else
            {
                ViewData["ToBuilding"] = toBuilding;
            }
            return View();
        }
    }
}
