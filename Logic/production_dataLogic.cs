using DAL.Handlers;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logic
{
    public class production_dataLogic : Iproduction_dataLogic
    {
        private readonly Iproduction_dataHandler _handler;
        private readonly ItreeviewHandler _treeviewhandler;
        public production_dataLogic(Iproduction_dataHandler handler, ItreeviewHandler treeviewhandler)
        {
            _treeviewhandler = treeviewhandler;
            _handler = handler;
        }

        public IEnumerable<production_dataDTO> ReadAll()
        {
            return _handler.Get();
        }

        public IEnumerable<production_dataDTO> GetByMachine(int port, int board)
        {
            return _handler.GetByMachine(port, board);
        }

        //COMPONENT MAKEN >w<
        public IEnumerable<ComponentDTO> GetAllComponents() {
            List<ComponentDTO> components = new List<ComponentDTO>();
            foreach (production_dataDTO c in ReadAll().GroupBy(x => x.treeview_id).Select(y => y.First()))
            {
                treeviewDTO treeview = _treeviewhandler.GetById(c.treeview_id);
                components.Add(new ComponentDTO(treeview.naam, treeview.id, 0, 0, 0));   
            }

            return components;
        }

    }
}
