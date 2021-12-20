using System;
using System.Collections.Generic;
using System.Text;

namespace DTO
{
    public class LifepageDTO
    {
        public LifepageDTO(int id, string name, string desc, int actions, int max)
        {
            treeview_id = id;
            this.name = name;
            description = desc;
            totalActions = actions;
            maxActions = max;
        }

        public int treeview_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public int totalActions { get; set; }
        public int maxActions { get; set; }
    }
}
