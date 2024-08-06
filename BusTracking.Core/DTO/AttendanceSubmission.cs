using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class AttendanceSubmission
    {
        public decimal Teacherid { get; set; }
        public List<CreateAttendace> Attendances { get; set; } = new();
    }
}
