using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data
{
    public partial class Testimonial
    {
        public decimal Testimonialid { get; set; }
        public string Message { get; set; } = null!;
        public decimal? PublisherId { get; set; }
        public string Status { get; set; } = null!;

        public virtual User? Publisher { get; set; }
    }
}
