using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ElectroPoint.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EletronicosController : ControllerBase
    {
        // GET: api/<EletronicosController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EletronicosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<EletronicosController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<EletronicosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EletronicosController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
