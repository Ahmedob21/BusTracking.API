using System;
using System.Collections.Generic;

namespace BusTracking.Core.Data
{
    public partial class bus
    {
        public bus()
        {
            Buslocations = new HashSet<Buslocation>();
            Busroutes = new HashSet<Busroute>();
            Children = new HashSet<Child>();
            Stops = new HashSet<Stop>();
        }

        public decimal Busid { get; set; }
        public string Busnumber { get; set; } = null!;
        public decimal? Childrennumber { get; set; }
        public decimal? Driverid { get; set; }
        public decimal? Teacherid { get; set; }

        public virtual User? Driver { get; set; }
        public virtual User? Teacher { get; set; }
        public virtual ICollection<Buslocation> Buslocations { get; set; }
        public virtual ICollection<Busroute> Busroutes { get; set; }
        public virtual ICollection<Child> Children { get; set; }
        public virtual ICollection<Stop> Stops { get; set; }
    }
}
