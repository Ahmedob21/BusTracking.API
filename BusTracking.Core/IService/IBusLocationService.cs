﻿using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IService
{
    public interface IBusLocationService
    {
        Task<AllBusesLocation> GetLatestLocation(decimal busId);
        Task UpdateBusLocation(Buslocation busLocation);
        Task<IEnumerable<AllBusesLocation>> GetAllBusesLocations();
    }
}
