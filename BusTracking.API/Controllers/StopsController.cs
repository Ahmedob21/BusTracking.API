using BusTracking.Core.Data;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StopsController : ControllerBase
    {
        private readonly IStopsService _stopsService;

        public StopsController(IStopsService stopsService)
        {
            _stopsService = stopsService;
        }


        [HttpPost]
        public async Task CreateStop(Stop stop) 
        {
            await _stopsService.CreateStop(stop);   
        }



        [HttpPut]
        public async Task UpdateStop(Stop stop) 
        { 
            await _stopsService.UpdateStop(stop);
        }


        [HttpDelete]
        public async Task DeleteStop(int stopid) 
        {
            await _stopsService.DeleteStop(stopid); 
        }


        [HttpGet ("{stopid}")]
        public async Task<Stop> GetStopById(int stopid) 
        {
            return await _stopsService.GetStopById(stopid);
        }


        [HttpGet]
        public async Task<List<Stop>> GetAllStops()
        {
            return await _stopsService.GetAllStops();
        }




    }
}
