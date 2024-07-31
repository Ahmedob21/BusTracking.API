using BusTracking.Core.Data;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController(ILoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]            //successfully working
        public IActionResult login([FromBody] Login login)
        {
            var result = _loginService.login(login);

            if (result == null)
            {
                return Unauthorized();
            }

            else
            {
                var token = result.Result.Token;
                return Ok(token);
            }
        }
    }
}
