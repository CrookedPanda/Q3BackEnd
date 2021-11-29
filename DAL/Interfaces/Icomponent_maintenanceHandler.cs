using DTO;
using System.Collections.Generic;

namespace DAL.Handlers
{
    public interface Icomponent_maintenanceHandler
    {
        IEnumerable<component_maintenanceDTO> GetByTreeViewId(int treeview_id);
    }
}