using BusTracking.Core.Data;
using BusTracking.Core.DTO;
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
    public class ChildRepository : IChildRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _context;
        public ChildRepository(IDbContext dBContext, ModelContext context)
        {
            _dbContext = dBContext;
            _context = context;
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

        public async Task<List<ChidrenResult>> GetAllChildren()
        {
            var result = await _dbContext.Connection.QueryAsync<ChidrenResult>("Children_package.get_all_Children", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public async Task<List<ChidrenResult>> GetChildrenByParentId(int parentid)
        {
            var result = await _dbContext.Connection.QueryAsync<ChidrenResult>("Children_package.get_all_Children", commandType: CommandType.StoredProcedure);
            result=result.Where(x=>x.Parentid==parentid);
            return result.ToList();
        }
        public async Task<ChidrenResult> GetChildById(int Childid)
        {
            var param = new DynamicParameters();
            param.Add("get_ChildId", Childid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<ChidrenResult>("Children_package.get_Children_by_id", param, commandType: CommandType.StoredProcedure);
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



        public async Task<List<Child>> SearchChildrenByName(string name)
        {
            var param = new DynamicParameters();
            param.Add("search_Name", name, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Child>("Search_Children_Package.Search_Children_By_Name", param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<List<ChidrenResult>> GetChildrenByDriverId(int driverid) {
        var param = new DynamicParameters();
            param.Add("get_DriverId", driverid , dbType: DbType.Int32, direction:ParameterDirection.Input);
            var result=await _dbContext.Connection.QueryAsync<ChidrenResult>("children_package.get_children_by_driverid",param, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<IEnumerable<PresentChildren>> GetTripChildren(decimal teacherId)
        {
            // Step 1: Retrieve the bus associated with the logged-in teacher
            var bus = await _context.Buses
                .Include(b => b.Children)
                .FirstOrDefaultAsync(b => b.Teacherid == teacherId);

            if (bus == null)
            {
                return Enumerable.Empty<PresentChildren>();
            }

            // Step 2: Retrieve the children in that bus
            var children = bus.Children
                .Where(c => c.Attendances.Any(a => a.Attendancedate == DateTimeOffset.Now.Date && a.Status == "Present"))
                .Select(c => new PresentChildren
                {
                    Childid = c.Childid,
                    Firstname = c.Firstname,
                    Lastname = c.Lastname,
                    Address = c.Address,
                    Parentid = c.Parentid,
                    Status = "Present" // Since we are filtering for "Present" status, you can directly set this.
                })
                .ToList();

            return children;
        }
    }
}
