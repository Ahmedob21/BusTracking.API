using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data
{
    public partial class Busroute
    {
        public decimal Routeid { get; set; }
        public decimal Sequence { get; set; }
        public decimal? BusesId { get; set; }
        public decimal? LocationId { get; set; }

        public virtual bus? Buses { get; set; }
        public virtual Buslocation? Location { get; set; }
    }
}
