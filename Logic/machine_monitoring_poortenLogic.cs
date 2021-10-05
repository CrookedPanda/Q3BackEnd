using DAL.Handlers;
using DTO;
using System;
using System.Collections.Generic;

namespace Logic
{
    public class machine_monitoring_poortenLogic : Imachine_monitoring_poortenLogic
    {
        private readonly Imachine_monitoring_poortenHandler _poortenHandler;
        public machine_monitoring_poortenLogic(Imachine_monitoring_poortenHandler handler)
        {
            _poortenHandler = handler;
        }

        public void Create(ComponentDTO component)
        {
        }

        public IEnumerable<machine_monitoring_poortenDTO> ReadAll()
        {
            return _poortenHandler.Get();
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
