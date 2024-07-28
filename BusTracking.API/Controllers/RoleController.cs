using BusTracking.Core.Data;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {


        private readonly IRoleService _roleService;

        public RoleController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        [HttpGet]
        public async Task<List<Role>> GetAllRole()
        {
            return await _roleService.GetAllRole();
        }
        [HttpGet("{roleid}")]
        public async Task<Role> GetRoleById(int roleid)
        {
            return await _roleService.GetRoleById(roleid);
        }
        [HttpPost]
        public async Task CreateRole(Role role)
        {
            await _roleService.CreateRole(role);
        }
        [HttpPut]
        public async Task UpdateRole(Role role)
        {
            await _roleService.UpdateRole(role);
        }
        [HttpDelete]
        public async Task DeleteRole(int roleid)
        {
            await _roleService.DeleteRole(roleid);
        }
    }
}
