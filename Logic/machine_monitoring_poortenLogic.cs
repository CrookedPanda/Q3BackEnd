using DAL.Handlers;
using DTO;
using System;
using System.Collections.Generic;

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
                machines.Add(new MachineDTO(poort.name, getComponentNames(poort), getTimestamps(poort)));
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
