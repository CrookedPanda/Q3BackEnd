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
    [Route("api/data")]
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

        [HttpGet("{port}")]
        [Route("port/{port}")]
        public IEnumerable<monitoring_dataDTO> GetByPort(int port)
        {
            return _logic.GetByPort(port);
        }

        // GET api/<monitoring_dataController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [Route("calc")]
        public void CalculateList()
        {
            _logic.CalculateList();
        }
    }
}
