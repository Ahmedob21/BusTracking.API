using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {


        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task CreateUser(UserModel userModel)
        {
            await _userService.CreateUser(userModel);
        }

        [HttpGet]
        public async Task<List<UserResult>> GetAllUser()
        {
            return await _userService.GetAllUser();
        }
        [HttpGet]
        [Route("GetAllTeachers")]
        public async Task<List<UserResult>> GetAllTeachers()
        {
            return await _userService.GetAllTeachers();
        }
        [HttpGet]
        [Route("GetAllDrivers")]
        public async Task<List<UserResult>> GetAllDrivers()
        {
            return await _userService.GetAllDrivers();
        }
        [HttpGet]
        [Route("GetAllParents")]
        public async Task<List<UserResult>> GetAllParents()
        {
            return await _userService.GetAllParents();
        }

        [HttpGet("{userId}")]
        public async Task<User> GetUserById(int userId)
        {
            return await _userService.GetUserById(userId);
        }
        [HttpPut]
        public async Task UpdateUser(User user)
        {
            await _userService.UpdateUser(user);
        }

        [HttpDelete("{userId}")]
        public async Task DeleteUser(int userid)
        {
            await _userService.DeleteUser(userid);
        }




        [HttpPost]
        [Route("UploadImage")]
        public string UploadImage()
        {
            var file = Request.Form.Files[0];
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullPath = Path.Combine("C:\\Users\\ahmad\\OneDrive\\Desktop\\asp.net\\chapters\\FinalProject\\BusTracking.API\\BusTracking.API\\Image\\", fileName);
            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            return fileName;
        }
    }
}
