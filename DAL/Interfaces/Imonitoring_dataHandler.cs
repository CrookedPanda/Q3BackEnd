using DTO;
using System;
using System.Collections.Generic;

namespace DAL.Handlers
{
    public interface Imonitoring_dataHandler
    {
        IEnumerable<monitoring_dataDTO> Get();
        IEnumerable<monitoring_dataDTO> GetByPort(int port);
        IEnumerable<monitoring_dataDTO> GetByMachine(int port, int board);
        IEnumerable<monitoring_dataDTO> GetByMachineDate(int port, int board, DateTime start, DateTime end);
        IEnumerable<monitoring_dataDTO> GetByMachineOneDay(int port, int board);
    }
}