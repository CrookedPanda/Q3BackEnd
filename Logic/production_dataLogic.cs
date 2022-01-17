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
        private readonly Icomponent_maintenanceHandler _maintenancehandler;
        public production_dataLogic(Iproduction_dataHandler handler, ItreeviewHandler treeviewhandler, Imonitoring_dataHandler monitoringData, Icomponent_maintenanceHandler maintenancehandler)
        {
            _treeviewhandler = treeviewhandler;
            _handler = handler;
            _monitoringData = monitoringData;
            _maintenancehandler = maintenancehandler;
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
            if (actions.Count() == 0)
            {
                return null;
            }
            // Maak component
            return new ComponentDTO(treeview.omschrijving, treeview.id, actions.Count(), 0, 0, getWeeklyActions(actions), getPastMaintenance(getComponentMaintenance(treeview.id)), getFutureMaintenance(getComponentMaintenance(treeview.id)));
        }

        public IEnumerable<ComponentDTO> GetComponentNames() {
            List<ComponentDTO> components = new List<ComponentDTO>();
            foreach (production_dataDTO c in ReadAll().GroupBy(x => x.treeview_id).Select(y => y.First())) // <--- Krijg alle production_data zonder duplicates 
            {
                ComponentDTO component = GetComponentName(c.treeview_id);

                if (component == null)
                {
                    continue;
                }

                components.Add(component);
            }

            return components;
        }

        public ComponentDTO GetComponentName(int treeview_id)
        {
            treeviewDTO treeview = _treeviewhandler.GetById(treeview_id);
            if (treeview == null)
            {
                return null;
            }
            return new ComponentDTO(treeview.omschrijving, treeview.id, 0, 0, 0, null, null, null);
        }

        public LifepageDTO GetLifespan(int treeview_id) {
            treeviewDTO treeview = _treeviewhandler.GetById(treeview_id); // nu kan je de data uit treeview gebruiken
            List<production_dataDTO> productionData = GetByTreeViewId(treeview_id).ToList(); // Alle productiondata (wanneer die op een machine heeft gezeten)
            List<monitoring_dataDTO> actions = new List<monitoring_dataDTO>();
            //als er geen data staat in de treeview kan je voor nu nog geen component maken
            if (treeview == null)
            {
                return null;
            }

            //bereken acties
            foreach (var pd in productionData)
            {
                DateTime start = pd.start_date.Date.Add(pd.start_time);
                DateTime end = pd.end_date.Date.Add(pd.end_time);
                actions.AddRange(_monitoringData.GetByMachineDate(pd.port, pd.board, start, end));
            }
            if (actions.Count() == 0)
            {
                return null;
            }
            // Maak component
            return new LifepageDTO(treeview.id, treeview.naam, treeview.omschrijving, actions.Count(), 150000);
        }

        public IEnumerable<LifepageDTO> GetAllLifespans() {
            List<LifepageDTO> lifespans = new List<LifepageDTO>();
            foreach (production_dataDTO c in ReadAll().GroupBy(x => x.treeview_id).Select(y => y.First())) 
            {
                treeviewDTO treeview = _treeviewhandler.GetById(c.treeview_id);

                LifepageDTO lifespan = GetLifespan(c.treeview_id);

                if (lifespan == null)
                {
                    continue;
                }

                lifespans.Add(lifespan);
            }

            return lifespans;
        }

        //method om de acties in weken te verdelen
        private List<ActionsDTO> getWeeklyActions(List<monitoring_dataDTO> actions)
        {
            List<DateTime> timestamps = new List<DateTime>();
            foreach (var item in actions)
            {
                timestamps.Add(item.timestamp);
            }

            List<ActionsDTO> actionsPerWeek = new List<ActionsDTO>();
            int weeknr = 1;
            try
            {
                DateTime currentTime = timestamps.Min().Date; //tijd van nu
                List<DateTime> getActionsCount = new List<DateTime>();
                foreach (DateTime time in timestamps)
                {
                    if (time < currentTime.AddDays(7)) //Kijk of de current entry waar je naar kijkt nog in de week zit
                    {
                        getActionsCount.Add(time);
                    }
                    else //als de tijd na deze week is, maak een nieuwe week
                    {
                        actionsPerWeek.Add(new ActionsDTO(weeknr, getActionsCount.Count())); //voeg dit halve uur blok toe aan de lijst 
                        currentTime = currentTime.AddDays(7);
                        weeknr++;
                        getActionsCount = new List<DateTime>(); //hier moet ik nieuwe maken
                    }
                }
            }
            catch (Exception)
            {
            }

            return actionsPerWeek;
        }

        private List<component_maintenanceDTO> getComponentMaintenance(int id) {
            return _maintenancehandler.GetByTreeViewId(id).ToList();
        }

        private List<component_maintenanceDTO> getFutureMaintenance(List<component_maintenanceDTO> maintenance) {
            List<component_maintenanceDTO> futureMaintenance = new List<component_maintenanceDTO>();

            foreach (var item in maintenance)
            {
                if (item.time > DateTime.Now)
                {
                    futureMaintenance.Add(item);
                }
            }

            return futureMaintenance;
        }

        private List<component_maintenanceDTO> getPastMaintenance(List<component_maintenanceDTO> maintenance)
        {
            List<component_maintenanceDTO> futureMaintenance = new List<component_maintenanceDTO>();

            foreach (var item in maintenance)
            {
                if (item.time < DateTime.Now)
                {
                    futureMaintenance.Add(item);
                }
            }

            return futureMaintenance;
        }
    }
}
