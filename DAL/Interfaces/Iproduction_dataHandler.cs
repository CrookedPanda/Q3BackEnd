using DTO;
using System.Collections.Generic;

namespace DAL.Handlers
{
    public interface Iproduction_dataHandler
    {
        IEnumerable<production_dataDTO> Get();
        IEnumerable<production_dataDTO> GetByMachine(int port, int board);
    }
}