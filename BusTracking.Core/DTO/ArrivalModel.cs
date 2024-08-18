using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class ArrivalModel
    {
        public decimal Arrivalid { get; set; }
        public decimal? Teacherid { get; set; }
        public decimal? Childid { get; set; }
        public string Status { get; set; } = null!;
        public string Firstname { get; set; } = null!;
        public string Lastname { get; set; } = null!;

    }
}
