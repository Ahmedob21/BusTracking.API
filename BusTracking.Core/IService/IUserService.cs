using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IService
{
    public interface IUserService
    {
        Task<List<UserResult>> GetAllUser();
        Task<List<UserResult>> GetAllTeachers();
        Task<List<UserResult>> GetAllDrivers();
        Task<List<UserResult>> GetAllParents();
        Task<User> GetUserById(int id);
        Task CreateUser(UserModel userModel);
        Task UpdateUser(User user);
        Task DeleteUser(int userid);
    }
}
