using DTO;
using System.Collections.Generic;

namespace DAL.Handlers
{
    public interface Imachine_monitoring_poortenHandler
    {
        IEnumerable<machine_monitoring_poortenDTO> Get();
        IEnumerable<machine_monitoring_poortenDTO> GetByName(string nm);
        IEnumerable<machine_monitoring_poortenDTO> GetMachine(int port, int board);
    }
}