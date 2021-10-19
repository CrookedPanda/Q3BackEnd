using Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using DTO;

namespace MachineMonitoring.Controllers
{
    [Route("api/machine")]
    [ApiController]
    public class poortenController : ControllerBase
    {
        Imachine_monitoring_poortenLogic _logic;
        public poortenController(Imachine_monitoring_poortenLogic logic)
        {
            _logic = logic;
        }

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<machine_monitoring_poortenDTO> Get()
        {
            return _logic.ReadAll();
        }

        [HttpGet("{name}")]
        [Route("PoortNaam/{name}")]
        public IEnumerable<machine_monitoring_poortenDTO> GetByName(string name)
        {
            return _logic.ReadByName(name);
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
