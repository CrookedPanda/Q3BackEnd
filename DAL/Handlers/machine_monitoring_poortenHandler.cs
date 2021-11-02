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

            return context.machine_monitoring_poorten.ToList();
        }

        public IEnumerable<machine_monitoring_poortenDTO> GetByName(string nm) {
            using var context = new ApplicationDataContext();

            return context.machine_monitoring_poorten. Where(x => x.name == nm).ToList();
        }

    }
}
