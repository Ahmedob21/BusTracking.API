using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data
{
    public partial class Child
    {
        public Child()
        {
            Arrivals = new HashSet<Arrival>();
            Attendances = new HashSet<Attendance>();
        }

        public decimal Childid { get; set; }
        public string Firstname { get; set; } = null!;
        public string? Address { get; set; }
        public decimal? Parentid { get; set; }
        public decimal? Busid { get; set; }
        public string Lastname { get; set; } = null!;

        public virtual bus? Bus { get; set; }
        public virtual User? Parent { get; set; }
        public virtual ICollection<Arrival> Arrivals { get; set; }
        public virtual ICollection<Attendance> Attendances { get; set; }
    }
}
