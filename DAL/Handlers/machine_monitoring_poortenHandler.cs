using System;
using System.Collections.Generic;
using System.Text;
using DTO;
using System.Linq;

namespace DAL.Handlers
{
    public class machine_monitoring_poortenHandler : Imachine_monitoring_poortenHandler
    {
        public IEnumerable<machine_monitoring_poortenDTO> Get()
        {
            using var context = new ApplicationDataContext();

            return context.machine_Monitoring_Poorten.ToList();
        }

    }
}
