using BusTracking.Core.Data;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusLocationController : ControllerBase
    {

        private readonly IBusLocationService _busLocationService;

        public BusLocationController(IBusLocationService busLocationService)
        {
            _busLocationService = busLocationService;
        }




        [HttpPost]
        public async Task<IActionResult> UpdateBusLocation([FromBody] Buslocation busLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _busLocationService.UpdateBusLocation(busLocation);
            return Ok();
        }

        [HttpGet("{busId}")]
        public async Task<ActionResult<Buslocation>> GetLatestLocation(int busId)
        {
            var location = await _busLocationService.GetLatestLocation(busId);
            if (location == null)
            {
                return NotFound();
            }
            return location;
        }






    }
}
