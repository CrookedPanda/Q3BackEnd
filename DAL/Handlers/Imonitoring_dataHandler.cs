using DTO;
using System.Collections.Generic;

namespace DAL.Handlers
{
    public interface Imonitoring_dataHandler
    {
        IEnumerable<monitoring_dataDTO> Get();
    }
}