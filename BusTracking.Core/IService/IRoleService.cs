using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IService
{
    public interface IRoleService
    {
        Task<List<Role>> GetAllRole();
        Task<Role> GetRoleById(int roleid);
        Task CreateRole(Role role);
        Task UpdateRole(Role role);
        Task DeleteRole(int roleid);
    }
}
