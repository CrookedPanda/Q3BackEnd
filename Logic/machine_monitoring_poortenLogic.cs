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
        public machine_monitoring_poortenLogic(Imachine_monitoring_poortenHandler handler, Imonitoring_dataLogic dataLogic)
        {
            _dataLogic = dataLogic;
            _poortenHandler = handler;
        }

        public IEnumerable<MachineDTO> getAllMachines()
        {
            
            List<MachineDTO> machines = new List<MachineDTO>();
            foreach (var poort in ReadAll())
            {
                machines.Add(new MachineDTO(poort.port.ToString(), null, null));
            }
            return machines;
        }

        public List<DateTime> getTimestamps(machine_monitoring_poortenDTO poort) {
            List<DateTime> timestamps = new List<DateTime>();
            foreach (var data in _dataLogic.GetByPort(poort.port))
            {
                timestamps.Add(data.timestamp);
            }
            return timestamps;
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
