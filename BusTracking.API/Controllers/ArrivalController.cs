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
        public async Task CreateArrival([FromBody]ArrivalResult arrival)
        {
            await _service.CreateArrival(arrival);
        }
    }
}
