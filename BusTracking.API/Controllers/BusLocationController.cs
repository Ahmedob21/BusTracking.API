using BusTracking.Core.Data;
using BusTracking.Core.DTO;
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



        [HttpGet]
        [Route("GetAllBusesLocations")]
        public async Task<IEnumerable<AllBusesLocation>> GetAllBusesLocations()
        {
            return await _busLocationService.GetAllBusesLocations();
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
        [Route("GetLatestLocation/{busId}")]
        public async Task<ActionResult<AllBusesLocation>> GetLatestLocation(decimal busId)
        {
            var location = await _busLocationService.GetLatestLocation(busId);
            if (location == null)
            {
                return NotFound();
            }
            return Ok(location);
        }






    }
}
