using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public async Task CreateTestimonial(Testimonial testimonial)
        {
           await _testimonialRepository.CreateTestimonial(testimonial);
        }

        public async Task DeleteTestimonial(int testimonialid)
        {
            await _testimonialRepository.DeleteTestimonial(testimonialid);
        }

        public async Task<List<TestimonialModel>> GetAllTestimonial()
        {
           return await _testimonialRepository.GetAllTestimonial();
        }

        public async Task<TestimonialModel> GetTestimonialById(int testimonialid)
        {
            return await _testimonialRepository.GetTestimonialById(testimonialid);
        }

        public async Task UpdateTestimonial(Testimonial testimonial)
        {
            await _testimonialRepository.UpdateTestimonial(testimonial);
        }
    }
}
