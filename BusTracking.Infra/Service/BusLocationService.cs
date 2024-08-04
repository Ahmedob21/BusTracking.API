using BusTracking.Core.Data;
using BusTracking.Core.DTO;
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

        public async Task<IEnumerable<AllBusesLocation>> GetAllBusesLocations()
        {
          return  await _busLocationRepository.GetAllBusesLocations();
        }
        public async Task<AllBusesLocation> GetLatestLocation(decimal busId)
        {
            return await _busLocationRepository.GetLatestLocation(busId);
        }

        public async Task UpdateBusLocation(Buslocation busLocation)
        {
            await _busLocationRepository.UpdateBusLocation(busLocation);
        }


    }
}
