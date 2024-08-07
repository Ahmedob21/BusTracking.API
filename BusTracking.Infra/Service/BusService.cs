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
    public class BusService : IBusService
    {
        private readonly IBusRepository _busRepository;

        public BusService(IBusRepository busRepository)
        {
            _busRepository = busRepository;
        }

       
        public async Task CreateBus(bus bus)
        {
            await _busRepository.CreateBus(bus);
        }

        public async Task UpdateBus(bus bus)
        {
            await _busRepository.UpdateBus(bus);
        }

        public async Task DeleteBus(int Busid)
        {
            await _busRepository.DeleteBus(Busid);
        }

        public async Task<bus> GetBusById(int Busid)
        {
            return await _busRepository.GetBusById(Busid);
        }

        public async Task<List<GetAllBuses>> GetAllBuses()
        {
            return await _busRepository.GetAllBuses();
        }
    }
}
