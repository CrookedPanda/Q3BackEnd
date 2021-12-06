using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace DAL.Handlers
{
    public class monitoring_dataHandler : Imonitoring_dataHandler
    {
        public IEnumerable<monitoring_dataDTO> Get()
        {
            using var context = new ApplicationDataContext();

            return context.monitoring_Data_202009.ToList();
        }

        public IEnumerable<monitoring_dataDTO> GetByPort(int port)
        {
            using var context = new ApplicationDataContext();

            return context.monitoring_Data_202009.Where(x => x.port == port).ToList();
        }
        public IEnumerable<monitoring_dataDTO> GetByMachine(int port, int board)
        {
            using var context = new ApplicationDataContext();

            return context.monitoring_Data_202009.Where(x => x.port == port && x.board == board).ToList();
        }

        public IEnumerable<monitoring_dataDTO> GetByMachineOneDay(int port, int board)
        {
            using var context = new ApplicationDataContext();

            return context.monitoring_Data_202009.Where(x => x.port == port && x.board == board && x.datum < new DateTime(2020, 9, 2).AddMinutes(40)).ToList();
        }

        public IEnumerable<monitoring_dataDTO> GetByMachineDate(int port, int board, DateTime start, DateTime end)
        {
            using var context = new ApplicationDataContext();

            return context.monitoring_Data_202009.Where(x => x.port == port && x.board == board && x.timestamp > start && x.timestamp < end).ToList();
        }
    }
}
