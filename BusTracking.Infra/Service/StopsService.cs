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
    public class StopsService : IStopsService
    {
        private readonly IStopsRepository _stopsRepository;

        public StopsService(IStopsRepository stopsRepository)
        {
            _stopsRepository = stopsRepository;
        }

        public async Task CreateStop(Stop stop)
        {
          await  _stopsRepository.CreateStop(stop);
        }

        public async Task DeleteStop(int stopid)
        {
            await _stopsRepository.DeleteStop(stopid);
        }

        public async Task<List<Stop>> GetAllStops()
        {
            return  await _stopsRepository.GetAllStops();
        }

        public async Task<Stop> GetStopById(int stopid)
        {
            return await _stopsRepository.GetStopById(stopid);
        }

        public async Task UpdateStop(Stop stop)
        {
            await _stopsRepository.UpdateStop(stop);
        }
    }
}
