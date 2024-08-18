using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.DTO;

namespace BusTracking.Core.IService
{
    public interface IArrivalService
    {
        Task CreateArrival(ArrivalResult arrival);
        Task DeletArrival(decimal arrivalid);
        Task UpdateArrival(decimal id, UpdateArrival updatedarrival);
        Task<List<ArrivalModel>> GellAllArrivalsByChildId(decimal childid);
    }
}
