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
        public async Task<IActionResult> UpdateBusLocation([FromBody] UpdateBusLocation busLocation)
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


        [HttpGet("{teacherId}")]
        [Route("GetBusLocationByTeacherId/{teacherId}")]
        public async Task<IActionResult> GetBusLocationByTeacherId(decimal teacherId)
        {
            try
            {
                var location = await _busLocationService.GetBusLocationByTeacherId(teacherId);

                if (location == null)
                {
                    return NotFound("Bus location not found.");
                }

                return Ok(location);
            }
            catch (InvalidOperationException ex)
            {
                
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpGet("{driverId}")]
        [Route("GetBusLocationByDriverId/{driverId}")]
     
        public async Task<IActionResult> GetBusLocationByDriverId(decimal driverId)
        {
            try
            {
                var location = await _busLocationService.GetBusLocationByDriverId(driverId);

                if (location == null)
                {
                    return NotFound("Bus location not found.");
                }

                return Ok(location);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }



        [HttpGet("{ParentId}")]
        [Route("GetBusLocationForParent/{ParentId}")]
        public async Task<IActionResult> GetBusLocationForParent(decimal parentId)
        {
            try
            {
                var location = await _busLocationService.GetBusLocationForParent(parentId);

                if (location == null)
                {
                    return NotFound("Bus location not found.");
                }

                return Ok(location);
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }




















    }
}
