using BusTracking.Core.Data;
using BusTracking.Core.ICommon;
using BusTracking.Core.IRepository;
using Dapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Repository
{
    public class UserStatisticsRepository : IUserStatisticsRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _context;
        public UserStatisticsRepository(IDbContext dBContext, ModelContext context)
        {
            _dbContext = dBContext;
            _context = context;
        }
        public async Task<(int TeacherCount, int StudentCount, int DriverCount , int ParentCount)> GetTeacherStudentCountsAsync()
        {
            
            var teacherCount = await _context.Users
                .Include(u => u.Role)
                .Where(u => u.Role.Rolename == "Teacher")
                .CountAsync();

            var parentCount = await _context.Users
                            .Include(u => u.Role)
                            .Where(u => u.Role.Rolename == "Parent")
                            .CountAsync();

            var driverCount = await _context.Users
                               .Include(u => u.Role)
                               .Where(u => u.Role.Rolename == "Driver")
                               .CountAsync();

            var studentCount = await _context.Children.CountAsync();

            return (teacherCount, studentCount, driverCount, parentCount);
        }




        public async Task<List<User>> GetUsersByYear(int year)
        {
            var param = new DynamicParameters();
            param.Add("p_year", year, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<User>("USER_STATISTICS_PACKAGE.Get_Users_By_Year", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<User>> GetUsersByMonthAndYear(int year, int month)
        {
            var param = new DynamicParameters();
            param.Add("p_year", year, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("p_month", month, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = await _dbContext.Connection.QueryAsync<User>("USER_STATISTICS_PACKAGE.Get_Users_By_Month_And_Year", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
