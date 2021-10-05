using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Logic;
using DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MachineMonitoring.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class monitoring_dataController : ControllerBase
    {
        Imonitoring_dataLogic _logic;
        public monitoring_dataController(Imonitoring_dataLogic logic)
        {
            _logic = logic;
        }
        // GET: api/<monitoring_dataController>
        [HttpGet]
        public IEnumerable<monitoring_dataDTO> Get()
        {
            return _logic.ReadAll();
        }

        // GET api/<monitoring_dataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<monitoring_dataController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<monitoring_dataController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<monitoring_dataController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
