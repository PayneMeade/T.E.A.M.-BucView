using BucView.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Web;
using System.Text.Json;
using System.Speech.Synthesis;

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
            if (HttpContext.Request.Cookies.ContainsKey("page"))
            {
                if(HttpContext.Request.Cookies["page"] != "Home")
                {
                    var page = HttpContext.Request.Cookies["page"];

                    return Redirect(page);
                }
                return View();
            }
            return View();
        }

        public IActionResult ResetCookie()
        {
            HttpContext.Response.Cookies.Append("page", "Home");
            return View("/Views/Home/Index.cshtml");
        }

        public IActionResult Speak(string id)
        {
            //Gets the Device information.
            string userAgent = Request.Headers["User-Agent"].ToString().ToLower();

            //Text to Speech only works on Windows.
            if (userAgent.Contains("windows"))
            {
                var speak = new SpeechSynthesizer();
                speak.SetOutputToDefaultAudioDevice();

                if (id != null)
                    //Id should be the directions for the Directions page or building description for the Tour page.
                    speak.SpeakAsync(id);
                else
                    speak.SpeakAsync("Error");
            }
 
            //Redirects back to previous page
            return Redirect(HttpContext.Request.Cookies["page"]);
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
            string rootDirectory = System.IO.Directory.GetCurrentDirectory();                                                    //Finds the path of the current working directory of the project
            return rootDirectory + $"{Path.DirectorySeparatorChar}JSON files{Path.DirectorySeparatorChar}{fileName}.json";       //Using our root directory from the RootPath() method find the file named 'rootFile1.txt.'      
        }
    }
}