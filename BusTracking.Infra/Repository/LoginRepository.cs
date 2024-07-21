using BusTracking.Core.Data;
using BusTracking.Core.DTO;
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
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext _dbContext;

        public LoginRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<LoginResult> login(Login login)
        {
            var param = new DynamicParameters();
            param.Add("E_mail", login.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Pass", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<LoginResult>("LOGIN_PACKAGE.Login", param, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

    }
}
