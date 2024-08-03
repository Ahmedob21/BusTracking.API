using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IRepository
{
    public interface IUserStatisticsRepository
    {
        Task<List<User>> GetUsersByYear(int year);
        Task<List<User>> GetUsersByMonthAndYear(int year, int month);
        Task<(int TeacherCount, int StudentCount, int DriverCount, int ParentCount)> GetTeacherStudentCountsAsync();
    }
}
