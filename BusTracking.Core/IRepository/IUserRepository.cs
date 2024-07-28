using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IRepository
{
    public interface IUserRepository
    {
        Task<List<UserResult>> GetAllUser();
        Task<User> GetUserById(int userid);
        Task CreateUser(UserModel userModel);
        Task UpdateUser(UpdateUser user);

        Task DeleteUser(int userid);
    }
}
