using DTO;
using Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MachineMonitoring.Controllers
{
    [Route("api/component")]
    [ApiController]
    public class production_dataController : ControllerBase
    {
        Iproduction_dataLogic _logic;
        public production_dataController(Iproduction_dataLogic logic)
        {
            _logic = logic;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<production_dataDTO> Get()
        {
            return _logic.ReadAll();
        }
    }
}
