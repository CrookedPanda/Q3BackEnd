using DTO;
using System.Collections.Generic;

namespace Logic
{
    public interface Imachine_monitoring_poortenLogic
    {
        void Create(ComponentDTO component);
        void Delete(int code);
        ComponentDTO Read(int code);
        IEnumerable<machine_monitoring_poortenDTO> ReadAll();
        void Update(ComponentDTO component);
    }
}