using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IRepository
{
    public interface IBusLocationRepository
    {
        Task<AllBusesLocation> GetLatestLocation(decimal busId);
        Task UpdateBusLocation(UpdateBusLocation busLocation);
        Task<IEnumerable<AllBusesLocation>> GetAllBusesLocations();
        Task<AllBusesLocation> GetBusLocationByTeacherId(decimal teacherId);
        Task<AllBusesLocation> GetBusLocationByDriverId(decimal driverId);
        Task<AllBusesLocation> GetBusLocationForParent(decimal ParentId);
    }
}
