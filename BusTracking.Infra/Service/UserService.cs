using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IRoleRepository _roleRepository;

        public UserService(IRoleRepository roleRepository, IUserRepository userRepository)
        {
            _roleRepository = roleRepository;
            _userRepository = userRepository;

        }
        public async Task CreateUser(UserModel userModel)
        {
            await _userRepository.CreateUser(userModel);

        }

        public async Task DeleteUser(int userid)
        {
            await _userRepository.DeleteUser(userid);
        }

        public async Task<List<UserResult>> GetAllUser()
        {
            return await _userRepository.GetAllUser();
        }

        public async Task<List<UserResult>> GetAllTeachers()
        {
            var result = await _userRepository.GetAllUser();
            var result2 = result.Where(x => x.Rolename == "Teacher");
            return result2.ToList();
        }

        public async Task<List<UserResult>> GetAllDrivers()
        {
            var result = await _userRepository.GetAllUser();
            var result2 = result.Where(x => x.Rolename == "Driver");
            return result2.ToList();
        }

        public async Task<List<UserResult>> GetAllParents()
        {
            var result = await _userRepository.GetAllUser();
            var result2 = result.Where(x => x.Rolename == "Parent");
            return result2.ToList();
        }



        public async Task<User> GetUserById(int userid)
        {
            return await _userRepository.GetUserById(userid);
        }

        public async Task UpdateUser(UpdateUser user)
        {
            await _userRepository.UpdateUser(user);
        }
    }
}
