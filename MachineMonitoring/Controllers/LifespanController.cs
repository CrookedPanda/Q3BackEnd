using DTO;
using Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MachineMonitoring.Controllers
{
    [Route("api/lifespan")]
    [ApiController]
    public class LifespanController : Controller
    {
        Iproduction_dataLogic _logic;
        public LifespanController(Iproduction_dataLogic logic)
        {
            _logic = logic;
        }

        [HttpGet]
        public IEnumerable<LifepageDTO> Get()
        {
            return _logic.GetAllLifespans();
        }
    }
}
