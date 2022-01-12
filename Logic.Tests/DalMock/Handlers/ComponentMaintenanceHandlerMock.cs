using DAL.Handlers;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests.DalMock.Handlers;

internal class ComponentMaintenanceHandlerMock : Icomponent_maintenanceHandler {
    private readonly List<component_maintenanceDTO> ComponentMaintenance = new List<component_maintenanceDTO>() {
        new component_maintenanceDTO() { id = 1, treeview_id = 1 },
        new component_maintenanceDTO() { id = 2, treeview_id = 2 },
        new component_maintenanceDTO() { id = 3, treeview_id = 1 },
        new component_maintenanceDTO() { id = 4, treeview_id = 3 },
        new component_maintenanceDTO() { id = 5, treeview_id = 4 },
        new component_maintenanceDTO() { id = 6, treeview_id = 1 }
    };

    public IEnumerable<component_maintenanceDTO> GetByTreeViewId(int treeview_id) {
        return ComponentMaintenance.Where(x => x.treeview_id == treeview_id);
    }
}
