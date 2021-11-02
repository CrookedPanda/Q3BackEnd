using DTO;
using System.Collections.Generic;

namespace DAL.Handlers
{
    public interface Imonitoring_dataHandler
    {
        IEnumerable<monitoring_dataDTO> Get();
        IEnumerable<monitoring_dataDTO> GetByPort(int port);
        IEnumerable<monitoring_dataDTO> GetByMachine(int port, int board);
    }
}