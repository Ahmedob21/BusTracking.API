using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class ChidrenResult
    {
        public string Parent { get; set; } = null!;
        public string Busnumber { get; set; } = null!;
        public decimal Childid { get; set; }
        public string Firstname { get; set; } = null!;
        public string? Address { get; set; }
        public decimal? Parentid { get; set; }
        public decimal? Busid { get; set; }
        public string Lastname { get; set; } = null!;
    }
}
