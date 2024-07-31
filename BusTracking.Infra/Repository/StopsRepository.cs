using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.ICommon;
using BusTracking.Core.IRepository;
using Dapper;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Repository
{
    public class StopsRepository : IStopsRepository
    {
        private readonly ModelContext _context;

        public StopsRepository(ModelContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Stop>> GetBusStops(int busId)
        {
            return await _context.Stops.Where(bs => bs.Busid == busId).ToListAsync();
        }

        public async Task<Stop> GetBusStop(decimal stopId)
        {
            return await _context.Stops.FindAsync(stopId);
        }

        public async Task AddBusStop(Stop busStop)
        {
            _context.Stops.Add(busStop);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBusStop(Stop busStop)
        {
            _context.Entry(busStop).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBusStop(decimal stopId)
        {
            var busStop = await _context.Stops.FindAsync(stopId);
            if (busStop != null)
            {
                _context.Stops.Remove(busStop);
                await _context.SaveChangesAsync();
            }
        }


    }
}
