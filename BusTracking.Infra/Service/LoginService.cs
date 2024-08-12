using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
    public class LoginService : ILoginService
    {
        private readonly ILoginRepository _loginRepository;

        public LoginService(ILoginRepository loginRepository)
        {
            _loginRepository = loginRepository;
        }

        public Task<LoginResult> login(Login login)
        {
            // return _loginRepository.login(login);
            var result = _loginRepository.login(login);
            if (result.Result == null)
            {
                return null;
            }
            else
            {
                var secrectKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("This is our secret key of the bus tracking system This is our secret key of the bus tracking system"));
                var signCred = new SigningCredentials(secrectKey, SecurityAlgorithms.HmacSha256);
                var claims = new List<Claim>
                {
                     new Claim ("RoleId",result.Result.RoleId.ToString()),
                     new Claim ("UserId", result.Result.UserId.ToString())
                };
                var tokenoptions = new JwtSecurityToken(

                    claims: claims,
                    expires: DateTime.Now.AddDays(5),
                    signingCredentials: signCred
                    );


                var token = new JwtSecurityTokenHandler().WriteToken(tokenoptions);
                result.Result.Token = token;
                return result;
            }
        }




    }
}
