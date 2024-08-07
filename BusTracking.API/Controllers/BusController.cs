using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IService;
using BusTracking.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly IBusService _busService;

        public BusController(IBusService busService)
        {
            _busService = busService;
        }
    

        [HttpPost]
        public async Task CreateBus([FromBody]bus bus)
        {
            await _busService.CreateBus(bus);
        }

        [HttpPut]
        public async Task UpdateBus(bus bus)
        {
            await _busService.UpdateBus(bus);
        }

        [HttpDelete]
        [Route("delete/{Busid}")]
        public async Task DeleteBus(int Busid)
        {
            await _busService.DeleteBus(Busid);
        }

        [HttpGet("{Busid}")]
        public async Task<bus> GetBusById(int Busid)
        {
            return await _busService.GetBusById(Busid);
        }

        [HttpGet]
        public async Task<List<GetAllBuses>> GetAllBuses()
        {
            return await _busService.GetAllBuses();
        }
        [HttpGet]
        [Route("CountBuses")]
        public async Task<Int32> CountBuses()
        {
            return _busService.GetAllBuses().Result.Count();
        }






    }
}
