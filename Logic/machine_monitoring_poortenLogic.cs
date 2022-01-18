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

        public IEnumerable<MachineDTO> getMachineFiltered(int port, int board) {
            List<MachineDTO> machines = new List<MachineDTO>();
            foreach (machine_monitoring_poortenDTO poort in GetMachine(port, board)) {
                List<DateTime> timestamps = getTimestamps(poort);
                machines.Add(new MachineDTO(poort.name, getComponentNames(poort), CreateUptimes(timestamps)));
            }
            return machines;
        }

        public IEnumerable<MachineDTO> getAllMachineFiltered() {
            foreach (machine_monitoring_poortenDTO poort in ReadAll()) {
                List<DateTime> timestamps = getTimestamps(poort);
                if (poort.name != null && timestamps.Count > 0) {
                    yield return new MachineDTO(poort.name, getComponentNames(poort), CreateUptimes(timestamps));
                }
            }
        }

        public List<UptimeDTO> GetOneDay(List<UptimeDTO> ts) {
            List<UptimeDTO> FirstDay = ts.Take(48).ToList();
            return FirstDay;
        }

        public List<DateTime> getTimestamps(machine_monitoring_poortenDTO machine) {
            List<DateTime> timestamps = new List<DateTime>();
            foreach (var data in _dataLogic.GetByMachineOneDay(machine.port, machine.board))
            {
                timestamps.Add(data.timestamp);
            }
            return timestamps;
        }

        private IEnumerable<UptimeDTO> CreateUptimes(List<DateTime> timeStamps) {
            bool on = true;
            DateTime maxTime = timeStamps.Max();

            DateTime? start = null;
            DateTime? lastTimeStamp = null;
            foreach (DateTime timeStamp in timeStamps) {
                if (maxTime.Subtract(timeStamp).TotalDays > 1) {
                    continue;
                }
                if (start == null) {
                    start = lastTimeStamp = timeStamp;
                    continue;
                }

                TimeSpan span = timeStamp.Subtract(lastTimeStamp.Value);
                lastTimeStamp = timeStamp;
                if (span.TotalMinutes > 2.0d) {
                    yield return new UptimeDTO(start.Value, timeStamp, on ? "on" : "off");
                    start = timeStamp;
                    on = !on;
                }
            }
        }

        public List<string> getComponentNames(machine_monitoring_poortenDTO machine) {
            List<string> components = new List<string>();
            foreach (var component in _productionLogic.GetByMachine(machine.port, machine.board))
            {
                components.Add(_productionLogic.GetComponentNameString(component.treeview_id));
            }
            return components;
        }

        public IEnumerable<machine_monitoring_poortenDTO> GetMachine(int port, int board) {
            return _poortenHandler.GetMachine(port, board);
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
