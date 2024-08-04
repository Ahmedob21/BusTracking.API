using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class AllBusesLocation
    {
        public string Busnumber { get; set; } = null!;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTimeOffset? Adate { get; set; }
        public decimal? BusId { get; set; }
    }
}
