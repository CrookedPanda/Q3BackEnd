using System;
using System.Collections.Generic;

namespace DTO
{
    public class MachineDTO
    {
        public MachineDTO(string nm, List<string> components, List<UptimeDTO> uptime)
        {
            name = nm;
            this.components = components;
            this.uptime = uptime;
        }
        public string name { get; set; }
        public List<string> components { get; set; }
        public List<UptimeDTO> uptime { get; set; }
    }
}
