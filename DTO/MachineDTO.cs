using System;
using System.Collections.Generic;

namespace DTO
{
    public class MachineDTO
    {
        public string name { get; set; }
        public List<ComponentDTO> components { get; set; }
        public List<UptimeDTO> uptime { get; set; }
    }
}
