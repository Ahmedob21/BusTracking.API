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
    public class UpdateProfileRepository : IUpdateProfileRepository
    {
        private readonly IDbContext _dbContext;

        public UpdateProfileRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task UpdateProfile(UpdateProfile profile)
        {
            var param = new DynamicParameters();
            param.Add("u_userID", profile.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_firstname", profile.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_lastname", profile.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_address", profile.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_username", profile.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_imagepath", profile.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_gender", profile.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_phone", profile.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("user__package.update_user_", param, commandType: CommandType.StoredProcedure);
        }
    }
}
