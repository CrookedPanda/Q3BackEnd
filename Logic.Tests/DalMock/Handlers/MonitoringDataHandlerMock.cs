using DAL.Handlers;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests.DalMock.Handlers;

internal class MonitoringDataHandlerMock : Imonitoring_dataHandler {
    private readonly List<monitoring_dataDTO> MonitoringData = new List<monitoring_dataDTO>();

    public IEnumerable<monitoring_dataDTO> Get() {
        return MonitoringData;
    }

    public IEnumerable<monitoring_dataDTO> GetByPort(int port) {
        return MonitoringData.Where(x => x.port == port);
    }

    public IEnumerable<monitoring_dataDTO> GetByMachine(int port, int board) {
        return MonitoringData.Where(x => x.port == port && x.board == board);
    }
}
