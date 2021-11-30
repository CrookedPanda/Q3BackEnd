using DAL.Handlers;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests.DalMock.Handlers;

internal class TreeViewHandlerMock : ItreeviewHandler {
    private readonly List<treeviewDTO> TreeView = new List<treeviewDTO>() {
        new treeviewDTO() { id = 1, },
        new treeviewDTO() { id = 2, },
        new treeviewDTO() { id = 3, },
        new treeviewDTO() { id = 4, }
    };

    public IEnumerable<treeviewDTO> Get() {
        return TreeView;
    }

    public treeviewDTO GetById(int treeview_id) {
        return TreeView.SingleOrDefault(x => x.id == treeview_id);
    }
}
