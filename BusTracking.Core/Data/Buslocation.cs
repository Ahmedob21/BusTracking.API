using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data
{
    public partial class Buslocation
    {
        public Buslocation()
        {
            Busroutes = new HashSet<Busroute>();
        }

        public decimal Locationid { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public DateTimeOffset? Adate { get; set; }
        public decimal? BusId { get; set; }

        public virtual bus? Bus { get; set; }
        public virtual ICollection<Busroute> Busroutes { get; set; }
    }
}
