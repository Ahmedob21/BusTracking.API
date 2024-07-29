using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class TestimonialModel
    {

        public decimal Testimonialid { get; set; }
        public string Message { get; set; } = null!;
        public decimal? Publisher_Id { get; set; }
        public string Status { get; set; } = null!;
        public string Full_Name { get; set; } = null!;




    }
}
