using DAL.Handlers;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests.DalMock.Handlers;

internal class ProductionDataHandlerMock : Iproduction_dataHandler {
    private readonly List<production_dataDTO> ProductionData = new List<production_dataDTO>();

    public IEnumerable<production_dataDTO> Get() {
        return ProductionData;
    }

    public IEnumerable<production_dataDTO> GetByMachine(int port, int board) {
        return ProductionData.Where(x => x.port == port && x.board == board);
    }
}
