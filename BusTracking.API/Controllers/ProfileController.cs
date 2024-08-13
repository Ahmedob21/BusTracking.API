using BusTracking.Core.DTO;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfileController : ControllerBase
    {
        private readonly IUpdateProfileService _updateProfileService;
        
        public ProfileController(IUpdateProfileService updateProfileService)
        {
            _updateProfileService = updateProfileService;
        }



        [HttpPost]                                      //successfully working
        [Authorize]
        public async Task UpdateProfile([FromBody] UpdateProfile profile)
        {
            await _updateProfileService.UpdateProfile(profile);
        }

    }
}
