using DTO;
using System.Collections.Generic;

namespace DAL.Handlers
{
    public interface Imachine_monitoring_poortenHandler
    {
        IEnumerable<machine_monitoring_poortenDTO> Get();
    }
}