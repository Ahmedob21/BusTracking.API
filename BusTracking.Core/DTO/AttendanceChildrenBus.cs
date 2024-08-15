using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class AttendanceChildrenBus
    {
        public decimal Childid { get; set; }
        public decimal? Parentid { get; set; }
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;
        public string parentName { get; set; } = null!;
        public string Busnumber { get; set; } = null!;
    }
}
