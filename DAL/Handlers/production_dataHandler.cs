using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Handlers
{
    class production_dataHandler : Iproduction_dataHandler
    {
        public IEnumerable<production_dataDTO> Get()
        {
            using var context = new ApplicationDataContext();

            return context.production_data.ToList();
        }
    }
}
