using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IRepository
{
    public interface IBusRepository
    {
        Task CreateBus(bus bus);
        Task UpdateBus(bus bus);
        Task DeleteBus(int Busid);
        Task<bus> GetBusById(int Busid);
        Task<List<GetAllBuses>> GetAllBuses();
        
    }
}
