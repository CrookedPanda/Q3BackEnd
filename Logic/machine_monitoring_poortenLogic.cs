using DAL.Handlers;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Logic
{
    public class machine_monitoring_poortenLogic : Imachine_monitoring_poortenLogic
    {
        private readonly Imachine_monitoring_poortenHandler _poortenHandler;
        private readonly Imonitoring_dataLogic _dataLogic;
        private readonly Iproduction_dataLogic _productionLogic;
        public machine_monitoring_poortenLogic(Imachine_monitoring_poortenHandler handler, Imonitoring_dataLogic dataLogic, Iproduction_dataLogic productionLogic)
        {
            _dataLogic = dataLogic;
            _poortenHandler = handler;
            _productionLogic = productionLogic;
        }

        public IEnumerable<MachineDTO> getMachineFiltered(int port, int board)
        {
            List<MachineDTO> machines = new List<MachineDTO>();
            foreach (var poort in GetMachine(port, board))
            {
                machines.Add(new MachineDTO(poort.name, getComponentNames(poort), createUptimes(getTimestamps(poort))));
            }
            return machines;
        }

        public IEnumerable<MachineDTO> getAllMachineFiltered()
        {
            List<MachineDTO> machines = new List<MachineDTO>();
            foreach (var poort in ReadAll())
            {
                if (poort.name != null && getTimestamps(poort).Count > 0)
                {
                    machines.Add(new MachineDTO(poort.name, getComponentNames(poort), createUptimes(getTimestamps(poort))));
                }
            }
            return machines;
        }

        public List<DateTime> getTimestamps(machine_monitoring_poortenDTO machine) {
            List<DateTime> timestamps = new List<DateTime>();
            foreach (var data in _dataLogic.GetByMachine(machine.port, machine.board))
            {
                timestamps.Add(data.timestamp);
            }
            return timestamps;
        }

        public List<UptimeDTO> createUptimes(List<DateTime> timestamps) {
            List<UptimeDTO> uptimes = new List<UptimeDTO>();
            try
            {
                DateTime currentTime = timestamps.Min(); //tijd van nu
                List<DateTime> timestampsToBeAdded = new List<DateTime>();
                    foreach (DateTime time in timestamps)
                    {
                        if (time < currentTime.AddMinutes(30)) //Kijk of de current entry waar je naar kijkt nog in het half uur blok zit
                        {
                            timestampsToBeAdded.Add(time); //Voeg tijd toe aan lijst met timestamps
                        }
                        else //als de tijd na dit half uur blok is, maak een nieuw tijdblok van 30 minuten 
                        {
                            uptimes.Add(new UptimeDTO(currentTime, timestampsToBeAdded)); //voeg dit halve uur blok toe aan de lijst
                            currentTime = currentTime.AddMinutes(30); 
                            timestampsToBeAdded = new List<DateTime>(); //als ik hier de lijst clear ipv een nieuwe maken, delete ik ook de timestampsToBeAdded uit uptimeDTO
                        }
                    }
            }
            catch (Exception)
            {
            }
            

            return uptimes;
        }

        public List<string> getComponentNames(machine_monitoring_poortenDTO machine) {
            List<string> components = new List<string>();
            foreach (var component in _productionLogic.GetByMachine(machine.port, machine.board))
            {
                components.Add(component.treeview_id.ToString() + ", " + component.treeview2_id.ToString());
            }
            return components;
        }

        public IEnumerable<machine_monitoring_poortenDTO> GetMachine(int port, int board) {
            return _poortenHandler.GetMachine(port, board);
        }

        public void Create(ComponentDTO component)
        {
        }

        public IEnumerable<machine_monitoring_poortenDTO> ReadAll()
        {
            return _poortenHandler.Get();
        }

        public IEnumerable<machine_monitoring_poortenDTO> ReadByName(string name) {
            return _poortenHandler.GetByName(name);
        }

        public void Delete(int code)
        {
        }

        public void Update(ComponentDTO component)
        {
        }

        public ComponentDTO Read(int code)
        {
            return null;
        }
    }
}
