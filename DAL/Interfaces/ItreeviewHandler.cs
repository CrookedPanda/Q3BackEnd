using DTO;
using System.Collections.Generic;

namespace DAL.Handlers
{
    public interface ItreeviewHandler
    {
        IEnumerable<treeviewDTO> Get();
        treeviewDTO GetById(int treeview_id);
    }
}