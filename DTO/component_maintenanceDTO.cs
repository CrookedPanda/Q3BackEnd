using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class component_maintenanceDTO
    {
        public int id { get; set; }
        public DateTime time { get; set; }
        public string type { get; set; }
        public int treeview_id { get; set; }
    }
}
