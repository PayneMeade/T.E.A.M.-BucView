using BucView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;
using System.Text.Json;

namespace BucView.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            Building building = new Building();

            if (HttpContext.Request.Cookies.ContainsKey("page") && HttpContext.Request.Cookies.ContainsKey("buildingName"))
            {
                var page = HttpContext.Request.Cookies["page"];
                building.buildingName = HttpContext.Request.Cookies["buildingName"];
                var buildingsList = new List<Building>();
                var filepath = FilePath("Building Info");
                var jsonText = System.IO.File.ReadAllText(filepath);
                buildingsList = JsonSerializer.Deserialize<List<Building>>(jsonText);
                building = buildingsList!.FirstOrDefault(a => a.buildingName!.Equals(building.buildingName))!;

                //ViewData["buildingName"] = buildingName;
                //return View();
                return View($"/Views/{page}/Index.cshtml", building);
            }
            else
            {
                return View();
            }
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public string FilePath(string fileName)
        {
            string rootDirectory = System.IO.Directory.GetCurrentDirectory();           //Finds the path of the current working directory of the project
            return rootDirectory + $"{Path.DirectorySeparatorChar}JSON files{Path.DirectorySeparatorChar}{fileName}.json";       //Using our root directory from the RootPath() method find the file named 'rootFile1.txt.'      
        }
    }
}