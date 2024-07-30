using BusTracking.Core.Data;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactUsController : ControllerBase
    {
        private readonly IContactUsService _contactUsService;

        public ContactUsController(IContactUsService contactUsService)
        {
            _contactUsService = contactUsService;
        }

        [HttpPost]
        public async Task CreateContactus(Contactu contactu)
        {
            await _contactUsService.CreateContactus(contactu);
        }

        [HttpDelete ("{contactusid}")]
        public async Task DeleteContactus(int contactusid)
        {
            await _contactUsService.DeleteContactus(contactusid);
        }


        [HttpGet]
        public async Task<List<Contactu>> GetAllContactus()
        {
            return await _contactUsService.GetAllContactus();
        }

        [HttpGet("{contactusid}")]
        public async Task<Contactu> GetContactusById(int contactusid)
        {
            return await GetContactusById(contactusid);
        }
    }
}
