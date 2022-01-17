using DAL.Handlers;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic.Tests.DalMock.Handlers;

internal class MonitoringDataHandlerMock : Imonitoring_dataHandler {
    private readonly List<monitoring_dataDTO> MonitoringData = new List<monitoring_dataDTO>() {
        new monitoring_dataDTO() { id = 1, board = 1, port = 1, timestamp = new DateTime(2021, 1, 1, 10, 0, 0) },
        new monitoring_dataDTO() { id = 2, board = 1, port = 2, timestamp = new DateTime(2021, 1, 1, 10, 30, 0) },
        new monitoring_dataDTO() { id = 3, board = 1, port = 3, timestamp = new DateTime(2021, 1, 1, 8, 0, 0) },
        new monitoring_dataDTO() { id = 4, board = 1, port = 4, timestamp = new DateTime(2021, 1, 1, 8, 30, 0) },
        new monitoring_dataDTO() { id = 5, board = 2, port = 1, timestamp = new DateTime(2021, 1, 1, 15, 0, 0) },
        new monitoring_dataDTO() { id = 6, board = 2, port = 2, timestamp = new DateTime(2021, 1, 1, 15, 30, 0) },
        new monitoring_dataDTO() { id = 7, board = 3, port = 1, timestamp = new DateTime(2021, 1, 1, 8, 0, 0) },
        new monitoring_dataDTO() { id = 8, board = 3, port = 3, timestamp = new DateTime(2021, 1, 1, 10, 0, 0) },
        new monitoring_dataDTO() { id = 9, board = 3, port = 3, timestamp = new DateTime(2021, 1, 1, 10, 30, 0) }
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

    public IEnumerable<monitoring_dataDTO> GetByMachineDate(int port, int board, DateTime start, DateTime end) {
        return MonitoringData.Where(x => x.port == port && x.board == board && x.timestamp > start && x.timestamp < end);
    }

    public IEnumerable<monitoring_dataDTO> GetByMachineOneDay(int port, int board) {
        return MonitoringData.Where(x => x.port == port && x.board == board && x.datum < new DateTime(2020, 9, 2).AddMinutes(40));
    }

    public int GetCountByMachineDate(int port, int board, DateTime start, DateTime end) {
        return MonitoringData.Count(x => x.port == port && x.board == board && x.timestamp > start && x.timestamp < end);
    }
}
