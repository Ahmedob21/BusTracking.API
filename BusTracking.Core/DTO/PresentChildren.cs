using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class PresentChildren
    {
        public decimal Childid { get; set; }
        public string Firstname { get; set; } = null!;
        public string? Address { get; set; }
        public decimal? Parentid { get; set; }
        public string Lastname { get; set; } = null!;
        public string Status { get; set; } = null!;
    }
}
