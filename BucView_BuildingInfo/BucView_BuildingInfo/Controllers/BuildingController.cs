using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BucView_BuildingInfo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuildingController : ControllerBase
    {
        // GET: api/<BuildingController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
    }
}
