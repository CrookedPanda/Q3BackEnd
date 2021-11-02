using System;
using System.Collections.Generic;

namespace DTO
{
    public class MachineDTO
    {
        public MachineDTO(string nm, List<ComponentDTO> components, List<UptimeDTO> uptime)
        {
            name = nm;
            this.components = components;
            this.uptime = uptime;
        }
        public string name { get; set; }
        public List<ComponentDTO> components { get; set; }
        public List<UptimeDTO> uptime { get; set; }
    }
}
