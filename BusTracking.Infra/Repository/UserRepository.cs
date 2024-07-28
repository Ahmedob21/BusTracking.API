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
        private readonly IDbContext _dbContext;
        public UserRepository(IDbContext dBContext)
        {
            _dbContext = dBContext;
        }

        public async Task CreateUser(UserModel userModel )
        {
            var param = new DynamicParameters();
            param.Add("First_name", userModel.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Last_name", userModel.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("User_name", userModel.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Pass", userModel.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("E_mail", userModel.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Phone_num", userModel.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("addres", userModel.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Role_id", userModel.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("Gender_name", userModel.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("Image_path", userModel.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("User_Id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbContext.Connection.ExecuteAsync("USER__PACKAGE.create_user_", param, commandType: CommandType.StoredProcedure);

            userModel.Userid = param.Get<int>("User_Id");
        }


        public async Task DeleteUser(int userid)
        {
            var param = new DynamicParameters();
            param.Add("d_userID", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("user__package.delete_user_", param, commandType: CommandType.StoredProcedure);

        }

        public async Task<List<UserResult>> GetAllUser()
        {
            var result = await _dbContext.Connection.QueryAsync<UserResult>("user__package.get_all_user_", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<User> GetUserById(int userid)
        {
            var param = new DynamicParameters();
            param.Add("get_userID", userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = await _dbContext.Connection.QueryAsync<User>("USER__PACKAGE.get_user__by_id", param , commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public async Task UpdateUser(UpdateUser user)
        {
            var param = new DynamicParameters();
            param.Add("u_userID", user.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            param.Add("u_firstname", user.Firstname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_lastname", user.Lastname, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_address", user.Address, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_username", user.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_imagepath", user.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            param.Add("u_phone", user.Phone, dbType: DbType.String, direction: ParameterDirection.Input);           
            param.Add("u_gender", user.Gender, dbType: DbType.String, direction: ParameterDirection.Input);
            await _dbContext.Connection.ExecuteAsync("user__package.update_user_", param, commandType: CommandType.StoredProcedure);

        }
    }
}
