using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Handlers
{
    public class treeviewHandler : ItreeviewHandler
    {
        public IEnumerable<treeviewDTO> Get()
        {
            using var context = new ApplicationDataContext();

            return context.treeview.ToList();
        }

        public treeviewDTO GetById(int treeview_id)
        {
            using var context = new ApplicationDataContext();

            return context.treeview.SingleOrDefault(x => x.id == treeview_id);
        }
    }
}
