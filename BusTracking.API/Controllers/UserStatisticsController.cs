using BusTracking.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserStatisticsController : ControllerBase
    {
        private readonly IUserStatisticsService _userStatisticsService;

        public UserStatisticsController(IUserStatisticsService userStatisticsService)
        {
            _userStatisticsService = userStatisticsService;
        }

        [HttpGet("year/{year}")]
        public async Task<IActionResult> GetUsersByYear(int year)
        {
            var users = await _userStatisticsService.GetUsersByYear(year);
            return Ok(users);
        }

        [HttpGet("year/{year}/month/{month}")]
        public async Task<IActionResult> GetUsersByMonthAndYear(int year, int month)
        {
            var users = await _userStatisticsService.GetUsersByMonthAndYear(year, month);
            return Ok(users);
        }


        [HttpGet("teacher-student-counts")]
        public async Task<IActionResult> GetTeacherStudentCounts()
        {
            // Get the counts from the service
            var counts = await _userStatisticsService.GetTeacherStudentCountsAsync();

            // Return the counts as a JSON object
            return Ok(new
            {
                TeacherCount = counts.TeacherCount,
                StudentCount = counts.StudentCount,
                DriverCount = counts.DriverCount,
                ParentCount = counts.ParentCount
            });
        }
    }
}
