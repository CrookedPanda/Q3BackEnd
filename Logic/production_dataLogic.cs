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
        private readonly Imonitoring_dataHandler _monitoringData;
        public production_dataLogic(Iproduction_dataHandler handler, ItreeviewHandler treeviewhandler, Imonitoring_dataHandler monitoringData)
        {
            _treeviewhandler = treeviewhandler;
            _handler = handler;
            _monitoringData = monitoringData;
        }

        public IEnumerable<production_dataDTO> ReadAll()
        {
            return _handler.Get();
        }

        public IEnumerable<production_dataDTO> GetByMachine(int port, int board)
        {
            return _handler.GetByMachine(port, board);
        }

        public IEnumerable<production_dataDTO> GetByTreeViewId(int treeview_id) {
            return _handler.GetByTreeViewId(treeview_id);
        }

        //COMPONENT MAKEN >w<
        public IEnumerable<ComponentDTO> GetAllComponents() {
            List<ComponentDTO> components = new List<ComponentDTO>();
            foreach (production_dataDTO c in ReadAll().GroupBy(x => x.treeview_id).Select(y => y.First())) // <--- Krijg alle production_data zonder duplicates 
            {
                ComponentDTO component = GetComponent(c.treeview_id);

                if (component == null) {
                    continue;
                }

                components.Add(component);   
            }

            return components;
        }

        public ComponentDTO GetComponent(int treeview_id) {
            treeviewDTO treeview = _treeviewhandler.GetById(treeview_id); // nu kan je de data uit treeview gebruiken
            List<production_dataDTO> productionData = GetByTreeViewId(treeview_id).ToList(); // Alle productiondata (wanneer die op een machine heeft gezeten)
            List<monitoring_dataDTO> actions = new List<monitoring_dataDTO>();
            //als er geen data staat in de treeview kan je voor nu nog geen component maken
            if (treeview == null)
            {
                return null;
            }
            //voeg monitoringdata toe aan actions
            foreach (var pd in productionData)
            {
                DateTime start = pd.start_date.Date.Add(pd.start_time);
                DateTime end = pd.end_date.Date.Add(pd.end_time);
                actions.AddRange(_monitoringData.GetByMachineDate(pd.port, pd.board, start, end));
            }

            // Maak component
            return new ComponentDTO(treeview.naam, treeview.id, actions.Count(), 0, 0);
        }

    }
}
