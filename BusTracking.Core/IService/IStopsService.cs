using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IService
{
    public interface IStopsService
    {
        Task<IEnumerable<Stop>> GetBusStops(int busId);
        Task<Stop> GetBusStop(decimal stopId);
        Task AddBusStop(Stop busStop);
        Task UpdateBusStop(Stop busStop);
        Task DeleteBusStop(decimal stopId);
    }
}
