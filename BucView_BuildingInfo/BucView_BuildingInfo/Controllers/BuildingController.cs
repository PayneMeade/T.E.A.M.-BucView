using BucView_BuildingInfo.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;
using System.Web;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BucView_BuildingInfo.Controllers
{
    [EnableCors]
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        //Returns all of the JSON
        // GET: api/<BuildingController>
        [HttpGet("all")]
        public IActionResult Get()
        {
            var buildingsList = new List<Building>();
            var filepath = FilePath("Building Info");
            string jsonText = System.IO.File.ReadAllText(FilePath("Building Info")); //Read json file
            if (jsonText != null)
            {
                return Ok(jsonText);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET api/<BuildingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "Building Info";
        }

        // POST api/<BuildingController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<BuildingController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<BuildingController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        public string FilePath(string fileName)
        {
            string rootDirectory = System.IO.Directory.GetCurrentDirectory();           //Finds the path of the current working directory of the project
            return rootDirectory + $"{Path.DirectorySeparatorChar}JSON files{Path.DirectorySeparatorChar}{fileName}.json";       //Using our root directory from the RootPath() method find the file named 'rootFile1.txt.'      
        }
    }
}
