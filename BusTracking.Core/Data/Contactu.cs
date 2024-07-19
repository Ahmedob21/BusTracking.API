using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data
{
    public partial class Contactu
    {
        public decimal Contactusid { get; set; }
        public string? UserName { get; set; }
        public string? Subject { get; set; }
        public string? UserEmail { get; set; }
        public string? Message { get; set; }
        public DateTimeOffset? Contactdate { get; set; }
    }
}
