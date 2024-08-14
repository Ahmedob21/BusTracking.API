using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.DTO;

namespace BusTracking.Core.IRepository
{
    public interface IArrivalRepository
    {
        Task CreateArrival(ArrivalResult arrival);
    }
}
