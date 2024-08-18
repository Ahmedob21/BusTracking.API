using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class UpdateArrival
    {
        public decimal Arrivalid { get; set; }
        public string Status { get; set; } = null!;
    }
}
