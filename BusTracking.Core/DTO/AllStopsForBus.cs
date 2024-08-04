using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class AllStopsForBus
    {
        public decimal Stopid { get; set; }
        public string Stopname { get; set; } = null!;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal? Busid { get; set; }
        public string Busnumber { get; set; } = null!;
    }
}
