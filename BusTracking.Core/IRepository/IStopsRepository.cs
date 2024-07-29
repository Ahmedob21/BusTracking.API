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
        Task CreateStop(Stop stop);
        Task UpdateStop(Stop stop);
        Task DeleteStop(int stopid);
        Task<Stop> GetStopById(int stopid);
        Task<List<Stop>> GetAllStops();
    }
}
