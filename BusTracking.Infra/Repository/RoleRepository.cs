using BusTracking.Core.Data;
using BusTracking.Core.ICommon;
using BusTracking.Core.IRepository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext _dBContext;

        public RoleRepository(IDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task CreateRole(Role role)
        {
            var param = new DynamicParameters();
            param.Add("role_Name", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dBContext.Connection.ExecuteAsync("ROLE_PACKAGE.Create_Role", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteRole(int roleid)
        {
            var param = new DynamicParameters();
            param.Add("Role_Id", roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dBContext.Connection.ExecuteAsync("ROLE_PACKAGE.Delete_Role", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Role>> GetAllRole()
        {
            var result = await _dBContext.Connection.QueryAsync<Role>("ROLE_PACKAGE.GetAllRole", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Role> GetRoleById(int roleid)
        {
            var param = new DynamicParameters();
            param.Add("Role_Id", roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dBContext.Connection.QueryAsync<Role>("ROLE_PACKAGE.GetRoleById", param, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();


        }

        public async Task UpdateRole(Role role)
        {
            var param = new DynamicParameters();
            param.Add("Role_Id", role.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("role_Name", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dBContext.Connection.ExecuteAsync("ROLE_PACKAGE.Update_Role", param, commandType: CommandType.StoredProcedure);
        }
    }
}
