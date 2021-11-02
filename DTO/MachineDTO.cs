using System;
using System.Collections.Generic;

namespace DTO
{
    public class MachineDTO
    {
        public MachineDTO(string nm, List<string> components, List<DateTime> uptime)
        {
            name = nm;
            this.components = components;
            this.uptime = uptime;
        }
        public string name { get; set; }
        public List<string> components { get; set; }
        public List<DateTime> uptime { get; set; }
    }
}
