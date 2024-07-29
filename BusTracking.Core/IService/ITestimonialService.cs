using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IService
{
    public interface ITestimonialService
    {
        Task<List<TestimonialModel>> GetAllTestimonial();
        Task<TestimonialModel> GetTestimonialById(int testimonialid);
        Task CreateTestimonial(Testimonial testimonial);
        Task UpdateTestimonial(Testimonial testimonial);
        Task DeleteTestimonial(int testimonialid);
    }
}
