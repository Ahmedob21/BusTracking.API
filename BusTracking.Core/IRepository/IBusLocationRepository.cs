using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IRepository
{
    public interface IBusLocationRepository
    {
        Task<Buslocation> GetLatestLocation(int busId);
        Task UpdateBusLocation(Buslocation busLocation);
    }
}
