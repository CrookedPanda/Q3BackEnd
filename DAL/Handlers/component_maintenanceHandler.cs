using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Handlers
{
    public class component_maintenanceHandler : Icomponent_maintenanceHandler
    {
        public IEnumerable<component_maintenanceDTO> GetByTreeViewId(int treeview_id)
        {
            using var context = new ApplicationDataContext();

            return context.component_maintenance.Where(x => x.treeview_id == treeview_id).ToList();
        }
    }
}
