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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;

        public RoleService(IRoleRepository roleRepository)
        {
            _roleRepository = roleRepository;
        }

        public async Task CreateRole(Role role)
        {
            await _roleRepository.CreateRole(role);
        }

        public async Task DeleteRole(int roleid)
        {
            await _roleRepository.DeleteRole(roleid);
        }

        public async Task<List<Role>> GetAllRole()
        {
            return await _roleRepository.GetAllRole();
        }

        public async Task<Role> GetRoleById(int roleid)
        {
            return await _roleRepository.GetRoleById(roleid);
        }

        public async Task UpdateRole(Role role)
        {
            await _roleRepository.UpdateRole(role);
        }
    }
}
