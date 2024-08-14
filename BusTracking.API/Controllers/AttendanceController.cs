using BusTracking.Core.DTO;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AttendanceController : ControllerBase
    {
        private readonly IAttendanceService _attendanceService;

        public AttendanceController(IAttendanceService attendanceService)
        {
            _attendanceService = attendanceService;
        }


        [HttpPost]
        public async Task<IActionResult> CreateAttendance([FromBody] AttendanceSubmission submission)
        {
            await _attendanceService.CreateAttendance(submission);
           return  Ok(new { message = "Attendance submitted successfully" });
        }



        [HttpGet("{childid}")]
        [Route("GetAttendanceForChild/{childid}")]
        public async Task<IEnumerable<AttendanceForChild>> GetAttendanceForChild(decimal childid)
        {
            return await _attendanceService.GetAttendanceForChild(childid);
        }


        [HttpGet("{teacherId}")]
        [Route("GetBusWithChildrenByTeacherId/{teacherId}")]
        public async Task<IEnumerable<AttendanceChildrenBus>> GetBusWithChildrenByTeacherId(decimal teacherId)
        {
            return await _attendanceService.GetBusWithChildrenByTeacherId(teacherId);
        }



        [HttpDelete ("{attendanceId}")]
        public async Task<IActionResult> DeleteAttendance(decimal attendanceId)
        {
            try
            {
                await _attendanceService.DeleteAttendance(attendanceId);
                return Ok(new { message = "Attendance deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpPut ("{attendanceId}")]
        public async Task<IActionResult> UpdateAttendance(decimal attendanceId, UpdateAttendance updateAttendance)
        {
            try
            {
                await _attendanceService.UpdateAttendance(attendanceId, updateAttendance);
                return Ok(new { message = "Attendance updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }


        [HttpGet("{parentId}")]
        [Route("GetChildAttendanceForParent/{parentId}")]
        public async Task<ActionResult<IEnumerable<AttendanceForChild>>> GetChildAttendanceForParent(decimal parentId)
        {
            var attendance = await _attendanceService.GetChildAttendanceForParent(parentId);
            if (attendance == null)
            {
                return NotFound();
            }
            return Ok(attendance);
        }






    }



    
}
