using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data
{
    public partial class Attendance
    {
        public decimal Attendanceid { get; set; }
        public DateTimeOffset? Attendancedate { get; set; }
        public decimal? Childid { get; set; }
        public decimal? Teacherid { get; set; }
        public string Status { get; set; } = null!;

        public virtual Child? Child { get; set; }
        public virtual User? Teacher { get; set; }
    }
}
