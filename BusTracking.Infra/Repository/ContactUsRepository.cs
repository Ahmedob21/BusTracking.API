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
    public class ContactUsRepository : IContactUsRepository
    {
        private readonly IDbContext _dbContext;
        public ContactUsRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateContactus(Contactu contactu)
        {
            var param = new DynamicParameters();
            param.Add("c_UserNAME", contactu.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_SUBJECT", contactu.Subject, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_UserEMAIL", contactu.UserEmail, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_MESSAGE", contactu.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("CONTACTUS_package.create_CONTACTUS", param, commandType: CommandType.StoredProcedure);
        }

        public async Task DeleteContactus(int contactusid)
        {
            var param = new DynamicParameters();
            param.Add("d_CONTACTUSID", contactusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("CONTACTUS_package.delete_CONTACTUS", param, commandType: CommandType.StoredProcedure);
        }

        public async Task<List<Contactu>> GetAllContactus()
        {
            var result = await _dbContext.Connection.QueryAsync<Contactu>("CONTACTUS_package.get_all_CONTACTUS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<Contactu> GetContactusById(int contactusid)
        {
            var param = new DynamicParameters();
            param.Add("get_CONTACTUS_by_id", contactusid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<Contactu>("CONTACTUS_package.get_CONTACTUS_by_id", param, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

       
    }
}
