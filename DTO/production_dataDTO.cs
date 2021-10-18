using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class production_dataDTO
    {
        public int id { get; set; }
        public int treeview_id { get; set; }
        public int treeview2_id { get; set; }
        public DateTime start_date { get; set; }
        public DateTime start_time { get; set; }
        public DateTime end_date { get; set; }
        public DateTime end_time { get; set; }
        public double amount { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int port { get; set; }
        public int board { get; set; }

    }
}
