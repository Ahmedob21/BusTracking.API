using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IRepository
{
    public interface IStopsRepository
    {
      
        Task<IEnumerable<AllStopsForBus>> GetBusStops(decimal busId);
        Task<AllStopsForBus> GetBusStop(decimal stopId);
        Task AddBusStop(Stop busStop);
        Task UpdateBusStop(Stop busStop);
        Task DeleteBusStop(decimal stopId);
    }
}
