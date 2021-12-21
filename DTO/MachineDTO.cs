using System;
using System.Collections.Generic;

namespace DTO {
    public class MachineDTO {
        public MachineDTO(string name, List<string> components, IEnumerable<UptimeDTO> data) {
            this.name = name;
            this.components = components;
            this.data = data;
        }
        public string name { get; set; }
        public List<string> components { get; set; }
        public IEnumerable<UptimeDTO> data { get; set; }
    }
}
