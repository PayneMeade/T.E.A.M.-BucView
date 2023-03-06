using BucView.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Web;
using System.Text.Json;

namespace BucView.Controllers
{
    public class TourController : Controller
    {
        public IActionResult Index(string id) //Id = Current Building as a string
        {
            Building building = new Building(); 
            if (id != null) //If start of tour...
            {
                var parsedString = HttpUtility.UrlDecode(id);  //decode the url parameter ( a "/" is represented as "%20" in the url)
                ViewData["Building"] = parsedString;
                var buildingsList = new List<Building>();
                var filepath = FilePath("Building Info");     
                var jsonText = System.IO.File.ReadAllText(FilePath("Building Info")); //Read json file
                buildingsList = JsonSerializer.Deserialize<List<Building>>(jsonText); //Deserialize json text into a list of building objects
                building = buildingsList!.FirstOrDefault(a => a.buildingName!.Equals(parsedString))!;   //Find the building that equals parsedString
            }
            else
            {
                ViewData["Building"] = "Error";
            }
            return View(building); //Pass building model to the view
        }
        /// <summary>
        /// Returns the filepath of a given file
        /// <returns></returns>
        public string FilePath(string fileName)
        {
            string rootDirectory = System.IO.Directory.GetCurrentDirectory();           //Finds the path of the current working directory of the project
            return rootDirectory + $"{Path.DirectorySeparatorChar}JSON files{Path.DirectorySeparatorChar}{fileName}.json";       //Using our root directory from the RootPath() method find the file named 'rootFile1.txt.'      
        }
    }
}
