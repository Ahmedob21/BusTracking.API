using BusTracking.Core.DTO;
using BusTracking.Core.IService;
using BusTracking.Infra.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrivalController : ControllerBase
    {
        private readonly IArrivalService _service;

        public ArrivalController(IArrivalService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task CreateArrival([FromBody] ArrivalResult arrival)
        {
            await _service.CreateArrival(arrival);
        }


        [HttpDelete("{arrivalid}")]
        public async Task DeletArrival(decimal arrivalid)
        {
            await _service.DeletArrival(arrivalid);
        }
        [HttpGet("{childid}")]
        public Task<List<ArrivalModel>> GellAllArrivalsByChildId(decimal childid)
        {
            return _service.GellAllArrivalsByChildId(childid);
        }
        [HttpPut("{id}")]
        public async Task UpdateArrival(decimal id, UpdateArrival updatedarrival)
        {
            await _service.UpdateArrival(id, updatedarrival);
        }
    }
}
