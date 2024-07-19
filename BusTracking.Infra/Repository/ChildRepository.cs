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
    public class ChildRepository : IChildRepository
    {
        private readonly IDbContext _dbContext;

        public ChildRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateChild(Child child)
        {
            var param = new DynamicParameters();
            param.Add("c_firstName", child.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_lastName", child.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_Address", child.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_ParentId", child.Parentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("c_BusId", child.Busid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Children_package.create_Children", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteChild(int Childid)
        {
            var param = new DynamicParameters();
            param.Add("d_ChildId", Childid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Children_package.delete_Children", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Child>> GetAllChildren()
        {
            var result = await _dbContext.Connection.QueryAsync<Child>("Children_package.get_all_Children", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Child> GetChildById(int Childid)
        {
            var param = new DynamicParameters();
            param.Add("get_ChildId", Childid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Child>("Children_package.get_Children_by_id", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task UpdateChild(Child child)
        {
            var param = new DynamicParameters();
            param.Add("u_ChildId", child.Childid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_firstName", child.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_lastName", child.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_Address", child.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_ParentId", child.Parentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_BusId", child.Busid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("Children_package.update_Children", param, commandType: CommandType.StoredProcedure);
        }



    }
}
