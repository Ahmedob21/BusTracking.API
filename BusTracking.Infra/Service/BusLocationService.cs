using BusTracking.Core.Data;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
    public class BusLocationService : IBusLocationService
    {
        private readonly IBusLocationRepository _busLocationRepository;

        public BusLocationService(IBusLocationRepository busLocationRepository)
        {
            _busLocationRepository = busLocationRepository;
        }


        public Task<Buslocation> GetLatestLocation(int busId)
        {
            return _busLocationRepository.GetLatestLocation(busId);
        }

        public Task UpdateBusLocation(Buslocation busLocation)
        {
            return _busLocationRepository.UpdateBusLocation(busLocation);
        }


    }
}
