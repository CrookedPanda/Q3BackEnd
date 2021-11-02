using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.Handlers;
using DTO;

namespace Logic
{
    public class monitoring_dataLogic : Imonitoring_dataLogic
    {
        private readonly Imonitoring_dataHandler _handler;
        public monitoring_dataLogic(Imonitoring_dataHandler handler)
        {
            _handler = handler;
        }

        public monitoring_dataLogic()
        {

        }

        public IEnumerable<monitoring_dataDTO> ReadAll()
        {
            return _handler.Get();
        }
        public IEnumerable<monitoring_dataDTO> GetByPort(int port) {
            return _handler.GetByPort(port);
        }

        public List<monitoring_dataDTO> CalculateList()
        {
            TimeSpan? timeOffline = TimeSpan.Parse("00:05:00");
            int boardStore = 0;
            int portStore = 0;
            DateTime? timeStore = null;
            List<monitoring_dataDTO> data = _handler.Get().ToList();
            foreach (var item in data)
            {
                if (boardStore == item.board && portStore == item.port)
                {
                    if (timeStore == null)
                    {
                        timeStore = item.timestamp;
                    }
                    var thing = timeStore.HasValue ? item.timestamp - timeStore : null;
                    if (thing > timeOffline)
                    {
                        Console.WriteLine("reached");
                    }
                }
                else
                {
                    boardStore = item.board;
                    portStore = item.port;
                }
                timeStore = item.timestamp;
            }
            return data;
        }
    }
}
