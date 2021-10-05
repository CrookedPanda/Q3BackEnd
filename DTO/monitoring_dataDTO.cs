using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class monitoring_dataDTO
    {
        public int id { get; set; }
        public int board { get; set; }
        public int port { get; set; }
        public int com { get; set; }
        public int code { get; set; }
        public int code2 { get; set; }
        public DateTime timestamp { get; set; }
        public DateTime datum { get; set; }
        public string mac_address { get; set; }
        public double shot_time { get; set; }
        public int previous_shot_id { get; set; }
    }
}
