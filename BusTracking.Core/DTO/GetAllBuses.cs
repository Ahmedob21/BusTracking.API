using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class GetAllBuses
    {
        public decimal Busid { get; set; }
        public string Busnumber { get; set; } = null!;
        public decimal? Childrennumber { get; set; }
        public decimal? Driverid { get; set; }
        public decimal? Teacherid { get; set; }
        public string driver_name { get; set; }
        public string teacher_name { get; set; }
    }
}
