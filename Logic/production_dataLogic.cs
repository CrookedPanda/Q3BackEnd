using DAL.Handlers;
using DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class production_dataLogic : Iproduction_dataLogic
    {
        private readonly Iproduction_dataHandler _handler;
        public production_dataLogic(Iproduction_dataHandler handler)
        {
            _handler = handler;
        }

        public IEnumerable<production_dataDTO> ReadAll()
        {
            return _handler.Get();
        }
    }
}
