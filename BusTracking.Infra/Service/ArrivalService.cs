using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.DTO;
using BusTracking.Core.IRepository;
using BusTracking.Core.IService;
using BusTracking.Infra.Repository;

namespace BusTracking.Infra.Service
{
    public class ArrivalService : IArrivalService
    {
        private readonly IArrivalRepository _repository;

        public ArrivalService(IArrivalRepository repository)
        {
            _repository = repository;
        }

        public async Task CreateArrival(ArrivalResult arrival)
        {
           await _repository.CreateArrival(arrival);
        }
    }
}
