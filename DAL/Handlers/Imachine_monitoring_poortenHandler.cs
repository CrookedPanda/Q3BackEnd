using DTO;
using System.Collections.Generic;

namespace DAL.Handlers
{
    public interface Imachine_monitoring_poortenHandler
    {
        IEnumerable<machine_monitoring_poortenDTO> Get();
        public IEnumerable<machine_monitoring_poortenDTO> GetByName(string nm);
    }
}