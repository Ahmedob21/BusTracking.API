using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {

        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }


        [HttpPost]
        [Authorize]
        public async Task CreateTestimonial(Testimonial testimonial)
        {
            await _testimonialService.CreateTestimonial(testimonial);
        }

        [HttpDelete]
        public async Task DeleteTestimonial(int testimonialid)
        {
            await _testimonialService.DeleteTestimonial(testimonialid);
        }

        [HttpGet]
        public async Task<List<TestimonialModel>> GetAllTestimonial()
        {
            return await _testimonialService.GetAllTestimonial();
        }

        [HttpGet("{testimonialid}")]
        public async Task<TestimonialModel> GetTestimonialById(int testimonialid)
        {
            return await _testimonialService.GetTestimonialById(testimonialid);
        }

        [HttpPut]
        public async Task UpdateTestimonial(Testimonial testimonial)
        {
            await _testimonialService.UpdateTestimonial(testimonial);
        }

    }
}
