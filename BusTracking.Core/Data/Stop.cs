using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data
{
    public partial class Stop
    {
        public decimal Stopid { get; set; }
        public string Stopname { get; set; } = null!;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal? Busid { get; set; }
        public DateTimeOffset? Addeddate { get; set; }
        public DateTimeOffset? Enddate { get; set; }

        public virtual bus? Bus { get; set; }
    }
}
