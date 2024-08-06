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
    }
}
