using BusTracking.Core.Data;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
    public class UserStatisticsService : IUserStatisticsService
    {
        private readonly IUserStatisticsRepository _userStatisticsRepository;
        public UserStatisticsService(IUserStatisticsRepository userStatisticsRepository)
        {
            _userStatisticsRepository = userStatisticsRepository;
        }




        public Task<List<User>> GetUsersByYear(int year)
        {
            return _userStatisticsRepository.GetUsersByYear(year);
        }

        public Task<List<User>> GetUsersByMonthAndYear(int year, int month)
        {
            return _userStatisticsRepository.GetUsersByMonthAndYear(year, month);
        }

        public async Task<(int TeacherCount, int StudentCount, int DriverCount, int ParentCount)> GetTeacherStudentCountsAsync()
        {
            return await _userStatisticsRepository.GetTeacherStudentCountsAsync();
        }
    }
}
