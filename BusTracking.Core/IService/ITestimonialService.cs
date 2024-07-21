using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.IService
{
    public interface ITestimonialService
    {
        Task<List<Testimonial>> GetAllTestimonial();
        Task<Testimonial> GetTestimonialById(int testimonialid);
        Task CreateTestimonial(Testimonial testimonial);
        Task UpdateTestimonial(Testimonial testimonial);
        Task DeleteTestimonial(int testimonialid);
    }
}
