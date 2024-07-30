using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.ICommon;
using BusTracking.Core.IRepository;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Repository
{
    public class StopsRepository : IStopsRepository
    {

        private readonly IDbContext _dbContext;

        public StopsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateStop(Stop stop)
        {
            var param = new DynamicParameters();
            param.Add("c_STOPNAME", stop.Stopname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_LATITUDE", stop.Latitude, dbType: DbType.Double, direction: ParameterDirection.Input);
            param.Add("c_LONGITUDE", stop.Longitude, dbType: DbType.Double, direction: ParameterDirection.Input);
            param.Add("c_BUSID", stop.Busid, dbType: DbType.Int32, direction: ParameterDirection.Input);

           await _dbContext.Connection.ExecuteAsync("STOPS_package.create_STOPS", param, commandType: CommandType.StoredProcedure);


        }

        public async Task DeleteStop(int stopid)
        {
            var param = new DynamicParameters();
            param.Add("d_STOPID", stopid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("STOPS_package.delete_STOPS", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Stop>> GetAllStops()
        {
            var result = await _dbContext.Connection.QueryAsync<Stop>("STOPS_package.get_all_STOPS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Stop> GetStopById(int stopid)
        {
            var param = new DynamicParameters();
            param.Add("gid_STOPID", stopid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Stop>("STOPS_package.gid_STOPS_by_id", param, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public async Task UpdateStop(Stop stop)
        {
            var param = new DynamicParameters();
            param.Add("u_STOPID", stop.Stopid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("c_STOPNAME", stop.Stopname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_LATITUDE", stop.Latitude, dbType: DbType.Double, direction: ParameterDirection.Input);
            param.Add("c_LONGITUDE", stop.Longitude, dbType: DbType.Double, direction: ParameterDirection.Input);
            param.Add("c_BUSID", stop.Busid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("STOPS_package.update_STOPS", param, commandType: CommandType.StoredProcedure);
        }
    }
}
