using System;
using System.Collections.Generic;
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
        public IEnumerable<monitoring_dataDTO> ReadAll()
        {
            return _handler.Get();
        }
        public IEnumerable<monitoring_dataDTO> GetByPort(int port) {
            return _handler.GetByPort(port);
        }

        public IEnumerable<monitoring_dataDTO> GetByMachine(int port, int board) {
            return _handler.GetByMachine(port, board);
        }
    }
}
