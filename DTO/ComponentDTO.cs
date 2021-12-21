using System;
using System.Collections.Generic;

namespace DTO
{
    public class ComponentDTO
    {
        public ComponentDTO(string naam, string desc, int id1, int actions, int board, int port, List<ActionsDTO> weeks, List<component_maintenanceDTO> past, List<component_maintenanceDTO> future)
        {
            this.naam = naam;
            description = desc;
            treeview_id = id1;
            actionsCount = actions;
            this.board = board;
            this.port = port;
            weeklyActions = weeks;
            pastMaintenance = past;
            futureMaintenance = future;
        }

        public string naam { get; set; }
        public string description { get; set; }
        public int treeview_id { get; set; }
        public int actionsCount{ get; set; }
        public int board { get; set; }
        public int port { get; set; }
        public List<ActionsDTO> weeklyActions { get; set; }
        public List<component_maintenanceDTO> pastMaintenance { get; set; }
        public List<component_maintenanceDTO> futureMaintenance { get; set; }
    }
}
