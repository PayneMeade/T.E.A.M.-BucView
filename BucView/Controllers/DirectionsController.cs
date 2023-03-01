using Microsoft.AspNetCore.Mvc;
using BucView.Models;
using System.Web;

namespace BucView.Controllers

{
    public class DirectionsController : Controller
    {
        public IActionResult Index(string id)
        {
            string toBuilding;
            var tour1 = new Tour();
            if (id == null)
            {
                toBuilding = tour1.getNext("tour1","");
                ViewData["FromBuilding"] = "N/A";
            }
            else
            {
                var parsedString = HttpUtility.UrlDecode(id);
                toBuilding = tour1.getNext("tour1", parsedString);
                ViewData["FromBuilding"] = parsedString;
            }
            ViewData["ToBuilding"] = toBuilding;
            return View();
        }
    }
}
