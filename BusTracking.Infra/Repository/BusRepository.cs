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
    public class BusRepository  : IBusRepository
    {
        private readonly IDbContext _dbContext;
        private readonly ModelContext _context;
        public BusRepository(IDbContext dBContext, ModelContext context)
        {
            _dbContext = dBContext;
            _context = context;
        }

      
        public async Task CreateBus(bus bus)
        {
            var param = new DynamicParameters();
            param.Add("c_BusNumber", bus.Busnumber, DbType.String, direction: ParameterDirection.Input);
            param.Add("c_ChildrenNumber", bus.Childrennumber, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("c_DriverId", bus.Driverid, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("c_TEACHERID", bus.Teacherid, DbType.Int32, direction: ParameterDirection.Input);


            var result = await _dbContext.Connection.ExecuteAsync("BUSES_PACKAGE.create_Buses", param, commandType: CommandType.StoredProcedure);

        }

        public async Task UpdateBus(bus bus)
        {
            var param = new DynamicParameters();
            param.Add("u_BusId", bus.Busid, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_BusNumber", bus.Busnumber, DbType.String, direction: ParameterDirection.Input);
            param.Add("u_ChildrenNumber", bus.Childrennumber, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_DriverId", bus.Driverid, DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_TEACHERID", bus.Teacherid, DbType.Int32, direction: ParameterDirection.Input);



            var result = await _dbContext.Connection.ExecuteAsync("BUSES_PACKAGE.update_Buses", param, commandType: CommandType.StoredProcedure);

        }

        public async Task DeleteBus(int Busid)
        {
            var param = new DynamicParameters();
            param.Add("d_BusId", Busid, DbType.Int32, direction: ParameterDirection.Input);


            var result = await _dbContext.Connection.ExecuteAsync("BUSES_PACKAGE.delete_Buses", param, commandType: CommandType.StoredProcedure);


        }

        public async Task<bus> GetBusById(int Busid)
        {
            var param = new DynamicParameters();
            param.Add("get_BusId", Busid, DbType.Int32, direction: ParameterDirection.Input);



            var result = await _dbContext.Connection.QueryAsync<bus>("BUSES_PACKAGE.get_Buses_by_id", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public async Task<List<GetAllBuses>> GetAllBuses()
        {
            var result = await _dbContext.Connection.QueryAsync<GetAllBuses>("BUSES_PACKAGE.get_all_Buses", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }







     










    }
}
