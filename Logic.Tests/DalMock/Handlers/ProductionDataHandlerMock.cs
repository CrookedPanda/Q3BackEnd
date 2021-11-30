using DAL.Handlers;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests.DalMock.Handlers;

internal class ProductionDataHandlerMock : Iproduction_dataHandler {
    private readonly List<production_dataDTO> ProductionData = new List<production_dataDTO>() {
        new production_dataDTO() { id = 1, board = 1, port = 1 },
        new production_dataDTO() { id = 2, board = 1, port = 2 },
        new production_dataDTO() { id = 3, board = 1, port = 3 },
        new production_dataDTO() { id = 4, board = 1, port = 4 },
        new production_dataDTO() { id = 5, board = 2, port = 1 },
        new production_dataDTO() { id = 6, board = 2, port = 2 },
        new production_dataDTO() { id = 7, board = 3, port = 1 },
        new production_dataDTO() { id = 8, board = 3, port = 3 }
    };

    public IEnumerable<production_dataDTO> Get() {
        return ProductionData;
    }

    public IEnumerable<production_dataDTO> GetByMachine(int port, int board) {
        return ProductionData.Where(x => x.port == port && x.board == board);
    }

    public IEnumerable<production_dataDTO> GetByTreeViewId(int treeview_id) {
        return ProductionData.Where(x => x.treeview_id == treeview_id);
    }
}
