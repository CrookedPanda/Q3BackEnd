using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Handlers
{
    public class production_dataHandler : Iproduction_dataHandler
    {
        public IEnumerable<production_dataDTO> Get()
        {
            using var context = new ApplicationDataContext();

            return context.production_data.ToList();
        }

        public IEnumerable<production_dataDTO> GetByMachine(int port, int board) {
            using var context = new ApplicationDataContext();

            return context.production_data.Where(x => x.port == port && x.board == board).ToList();
        }

        public IEnumerable<production_dataDTO> GetByTreeViewId(int treeview_id) {
            using var context = new ApplicationDataContext();

            return context.production_data.Where(x => x.treeview_id == treeview_id).ToList();
        }
    }
}
