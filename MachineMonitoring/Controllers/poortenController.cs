﻿using Logic;
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
    [Route("api/poorten")]
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

        [HttpGet("{port}/{board}")]
        public IEnumerable<machine_monitoring_poortenDTO> GetMachine(int port, int board) {
            return _logic.GetMachine(port, board);
        }
        
        [HttpGet("{port}/{board}")]
        [Route("machine/{port}/{board}")]
        public IEnumerable<MachineDTO> GetMachineFiltered(int port, int board)
        {
            return _logic.getMachineFiltered(port, board);
        }

        [Route("machine")]
        public IEnumerable<MachineDTO> GetAllMachineFiltered(int port, int board)
        {
            return _logic.getAllMachineFiltered();
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
