using DAL.Handlers;
using DTO;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests.DalMock.Handlers;

internal class PoortenHandlerMock : Imachine_monitoring_poortenHandler {
    private readonly List<machine_monitoring_poortenDTO> Poorten = new List<machine_monitoring_poortenDTO>() {
        new machine_monitoring_poortenDTO() { id = 1, board = 1, port = 1, name = "foo", volgorde = 0, visible = 1 },
        new machine_monitoring_poortenDTO() { id = 2, board = 1, port = 1, name = "bar", volgorde = 0, visible = 1 },
        new machine_monitoring_poortenDTO() { id = 3, board = 2, port = 1, name = "baz", volgorde = 0, visible = 1 },
        new machine_monitoring_poortenDTO() { id = 4, board = 1, port = 2, name = "foo", volgorde = 0, visible = 1 }
    };

    public IEnumerable<machine_monitoring_poortenDTO> Get() {
        return Poorten;
    }

    public IEnumerable<machine_monitoring_poortenDTO> GetByName(string nm) {
        return Poorten.Where(x => x.name == nm);
    }

    public IEnumerable<machine_monitoring_poortenDTO> GetMachine(int port, int board) {
        return Poorten.Where(x => x.board == board && x.port == port);
    }
}
