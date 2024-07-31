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



        [HttpGet("{busId}")]
        public async Task<ActionResult<IEnumerable<Stop>>> GetBusStops(int busId)
        {
            var busStops = await _stopsService.GetBusStops(busId);
            return Ok(busStops);
        }

        [HttpGet("stop/{stopId}")]
        public async Task<ActionResult<Stop>> GetBusStop(decimal stopId)
        {
            var busStop = await _stopsService.GetBusStop(stopId);
            if (busStop == null)
            {
                return NotFound();
            }
            return Ok(busStop);
        }

        [HttpPost]
        public async Task<IActionResult> AddBusStop([FromBody] Stop busStop)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _stopsService.AddBusStop(busStop);
            return CreatedAtAction(nameof(GetBusStop), new { stopId = busStop.Stopid }, busStop);
        }

        [HttpPut("{stopId}")]
        public async Task<IActionResult> UpdateBusStop(decimal stopId, [FromBody] Stop busStop)
        {
            if (stopId != busStop.Stopid)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _stopsService.UpdateBusStop(busStop);
            return NoContent();
        }

        [HttpDelete("{stopId}")]
        public async Task<IActionResult> DeleteBusStop(decimal stopId)
        {
            await _stopsService.DeleteBusStop(stopId);
            return NoContent();
        }



    }
}
