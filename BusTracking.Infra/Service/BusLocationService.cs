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

        public async Task<AllBusesLocation> GetBusLocationByDriverId(decimal driverId)
        {
            return await _busLocationRepository.GetBusLocationByDriverId(driverId);
        }

        public async Task<AllBusesLocation> GetBusLocationByTeacherId(decimal teacherId)
        {
           return await _busLocationRepository.GetBusLocationByTeacherId(teacherId);
        }

        public async Task<AllBusesLocation> GetBusLocationForParent(decimal parentId)
        {
            return await _busLocationRepository.GetBusLocationForParent(parentId);
        }

        public async Task<AllBusesLocation> GetLatestLocation(decimal busId)
        {
            return await _busLocationRepository.GetLatestLocation(busId);
        }

        public async Task UpdateBusLocation(UpdateBusLocation busLocation)
        {
            await _busLocationRepository.UpdateBusLocation(busLocation);
        }





    }
}
