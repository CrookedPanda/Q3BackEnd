using DAL.Handlers;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests.DalMock.Handlers;

internal class MonitoringDataHandlerMock : Imonitoring_dataHandler {
    private readonly List<monitoring_dataDTO> MonitoringData = new List<monitoring_dataDTO>() {
        new monitoring_dataDTO() { id = 1, board = 1, port = 1 },
        new monitoring_dataDTO() { id = 2, board = 1, port = 2 },
        new monitoring_dataDTO() { id = 3, board = 1, port = 3 },
        new monitoring_dataDTO() { id = 4, board = 1, port = 4 },
        new monitoring_dataDTO() { id = 5, board = 2, port = 1 },
        new monitoring_dataDTO() { id = 6, board = 2, port = 2 },
        new monitoring_dataDTO() { id = 7, board = 3, port = 1 },
        new monitoring_dataDTO() { id = 8, board = 3, port = 3 }
    };

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
