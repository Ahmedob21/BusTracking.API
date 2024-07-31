using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IService
{
    public interface IBusLocationService
    {
        Task<Buslocation> GetLatestLocation(int busId);
        Task UpdateBusLocation(Buslocation busLocation);
    }
}
