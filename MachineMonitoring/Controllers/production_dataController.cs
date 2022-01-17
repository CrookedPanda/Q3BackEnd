using DTO;
using Logic;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MachineMonitoring.Controllers
{
    [Route("api/components")]
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
        public IEnumerable<ComponentDTO> Get()
        {
            return _logic.GetAllComponents();
        }

        [HttpGet("{treeview_id}")]
        public ComponentDTO GetComponent(int treeview_id)
        {
            return _logic.GetComponent(treeview_id);
        }
        

        [HttpGet("{port}/{board}")]
        public IEnumerable<production_dataDTO> GetByMachine(int port, int board)
        {
            return _logic.GetByMachine(port, board);
        }

        [HttpGet("names")]
        public IEnumerable<ComponentDTO> GetNames()
        {
            return _logic.GetComponentNames();
        }
    }
}
