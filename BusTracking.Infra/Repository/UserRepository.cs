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
    public class UserRepository: IUserRepository
    {
        private readonly IDbContext _dBContext;
        public UserRepository(IDbContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task CreateUser(UserModel userModel )
        {
            var param = new DynamicParameters();
            param.Add("Firstname", userModel.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Lastname", userModel.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Username", userModel.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Password", userModel.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Email", userModel.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Phone", userModel.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Address", userModel.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Roleid", userModel.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("Gender", userModel.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Imagepath", userModel.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("UserId", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dBContext.Connection.ExecuteAsync("User_Package.Create_User", param, commandType: CommandType.StoredProcedure);

            userModel.Userid = param.Get<int>("UserId");
        }


        public async Task DeleteUser(int userid)
        {
            var param = new DynamicParameters();
            param.Add("d_userID", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dBContext.Connection.ExecuteAsync("user__package.delete_user_", param, commandType: CommandType.StoredProcedure);

        }

        public async Task<List<UserResult>> GetAllUser()
        {
            var result = await _dBContext.Connection.QueryAsync<UserResult>("user__package.get_all_user_", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<User> GetUserById(int userid)
        {
            var param = new DynamicParameters();
            param.Add("get_userID", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dBContext.Connection.QueryAsync<User>("USER__PACKAGE.get_user__by_id", param , commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public async Task UpdateUser(User user)
        {
            var param = new DynamicParameters();
            param.Add("u_userID", user.Userid, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_firstname", user.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_lastname", user.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_address", user.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_username", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_imagepath", user.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("c_phone", user.Phone, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("c_roleid", user.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("c_gender", user.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dBContext.Connection.ExecuteAsync("user__package.update_user_", param, commandType: CommandType.StoredProcedure);

        }
    }
}
