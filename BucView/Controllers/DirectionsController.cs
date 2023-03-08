using Microsoft.AspNetCore.Mvc;
using BucView.Models;
using System.Web;
using System.Text.Json;

namespace BucView.Controllers

{
    public class DirectionsController : Controller
    {
        public IActionResult Index(string id)   //Id = Current Building as a string
        {
            Building building = new Building();
            string toBuilding;
            string fromBuilding;
            var tour1 = new Tour();
            if (id == null) //If start of tour...
            {
                toBuilding = tour1.getNext("tour1",""); //Find first building in the list
                fromBuilding = "N/A";   
                ViewData["FromBuilding"] = fromBuilding;
            }
            else
            {
                fromBuilding = HttpUtility.UrlDecode(id); //Decode url parameter
                toBuilding = tour1.getNext("tour1", fromBuilding);  //Get the next building as a string
                ViewData["FromBuilding"] = fromBuilding;
            }
            var buildingsList = new List<Building>();
            var filepath = FilePath("Building Info");
            var jsonText = System.IO.File.ReadAllText(FilePath("Building Info")); //Read json file
            buildingsList = JsonSerializer.Deserialize<List<Building>>(jsonText); //Deserialize json text into a list of building
            building = buildingsList!.FirstOrDefault(a => a.buildingName!.Equals(toBuilding))!; //Find the building where buildingName = toBuilding
            ViewData["ToBuilding"] = toBuilding;
            return View(building);  //Pass model to view
        }
        public string FilePath(string fileName)
        {
            string rootDirectory = System.IO.Directory.GetCurrentDirectory();           //Finds the path of the current working directory of the project
            return rootDirectory + $"{Path.DirectorySeparatorChar}JSON files{Path.DirectorySeparatorChar}{fileName}.json";       //Using our root directory from the RootPath() method find the file named 'rootFile1.txt.'      
        }
    }
}
