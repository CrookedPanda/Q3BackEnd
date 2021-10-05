using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace DAL.Handlers
{
    public class monitoring_dataHandler : Imonitoring_dataHandler
    {
        public IEnumerable<monitoring_dataDTO> Get()
        {
            using var context = new ApplicationDataContext();

            return context.monitoring_Data_202009.ToList();
        }
    }
}
