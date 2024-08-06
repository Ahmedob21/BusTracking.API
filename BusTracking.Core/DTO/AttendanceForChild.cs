using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class AttendanceForChild
    {
        public decimal Attendanceid { get; set; }
        public DateTimeOffset? Attendancedate { get; set; }
        public string Status { get; set; } = null!;
        public decimal? Childid { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
    }
}
