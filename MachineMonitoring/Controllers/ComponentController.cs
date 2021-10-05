using Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MachineMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentController : ControllerBase
    {
        ComponentLogic _logic = new ComponentLogic();

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            List<string> components = new List<string>();

            foreach (var item in _logic.ReadAll())
            {
                components.Add(JsonSerializer.Serialize(item));
            }
            return components.ToArray();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{code}")]
        public string Get(int code)
        {
            return JsonSerializer.Serialize(_logic.Read(code));
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
