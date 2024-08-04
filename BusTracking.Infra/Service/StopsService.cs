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
    public class StopsService : IStopsService
    {
        private readonly IStopsRepository _stopsRepository;

        public StopsService(IStopsRepository stopsRepository)
        {
            _stopsRepository = stopsRepository;
        }

        public Task<IEnumerable<AllStopsForBus>> GetBusStops(decimal busId)
        {
            return _stopsRepository.GetBusStops(busId);
        }

        public Task<AllStopsForBus> GetBusStop(decimal stopId)
        {
            return _stopsRepository.GetBusStop(stopId);
        }

        public Task AddBusStop(Stop busStop)
        {
            return _stopsRepository.AddBusStop(busStop);
        }

        public Task UpdateBusStop(Stop busStop)
        {
            return _stopsRepository.UpdateBusStop(busStop);
        }

        public Task DeleteBusStop(decimal stopId)
        {
            return _stopsRepository.DeleteBusStop(stopId);
        }
    }
}
