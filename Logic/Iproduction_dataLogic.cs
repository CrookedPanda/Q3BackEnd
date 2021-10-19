using DTO;
using System.Collections.Generic;

namespace Logic
{
    public interface Iproduction_dataLogic
    {
        IEnumerable<production_dataDTO> ReadAll();
    }
}