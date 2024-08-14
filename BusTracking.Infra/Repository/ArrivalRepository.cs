using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IRepository;
using Microsoft.EntityFrameworkCore;

namespace BusTracking.Infra.Repository
{
    public class ArrivalRepository :IArrivalRepository
    {
        private readonly ModelContext _context;

        public ArrivalRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task CreateArrival(ArrivalResult arrival) 
        {
            var arrivalEntity = new Arrival
            {
                Status = arrival.Status,
                Childid = arrival.Childid,
                Teacherid = arrival.Teacherid 
            };
             _context.Arrivals.Add(arrivalEntity);
        await _context.SaveChangesAsync();
        }

    }
}
