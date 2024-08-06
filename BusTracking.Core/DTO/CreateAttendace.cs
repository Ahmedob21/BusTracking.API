using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
    public class CreateAttendace
    {

        public string Status { get; set; } = null!;
        public decimal? Teacherid { get; set; }
        public decimal Childid { get; set; }

    }
}
