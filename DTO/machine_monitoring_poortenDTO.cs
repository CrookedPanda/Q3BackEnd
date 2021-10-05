using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class machine_monitoring_poortenDTO
    {
        public int id { get; set; }
        public int board { get; set; }
        public int port { get; set; }
        public string name { get; set; }
        public int volgorde { get; set; }
        public int visible { get; set; }

        public machine_monitoring_poortenDTO()
        {

        }
    }
}
