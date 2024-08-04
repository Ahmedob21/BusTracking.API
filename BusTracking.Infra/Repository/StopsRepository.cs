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

        public async Task<IEnumerable<AllStopsForBus>> GetBusStops(decimal busId)
        {
            var stops = await _context.Stops
                .Include(stop => stop.Bus)
                .Where(stop => stop.Busid == busId)
                .Select(stop => new AllStopsForBus
                {
                    Stopid = stop.Stopid,
                    Stopname = stop.Stopname,
                    Latitude = stop.Latitude,
                    Longitude = stop.Longitude,
                    Busid = stop.Busid,
                    Busnumber = stop.Bus.Busnumber 
                })
                .ToListAsync();

            return stops;
        }

        public async Task<AllStopsForBus> GetBusStop(decimal stopId)
        {
            var stop = await _context.Stops
        .Include(s => s.Bus)
        .Where(s => s.Stopid == stopId)
        .Select(s => new AllStopsForBus
        {
            Stopid = s.Stopid,
            Stopname = s.Stopname,
            Latitude = s.Latitude,
            Longitude = s.Longitude,
            Busid = s.Busid,
            Busnumber = s.Bus.Busnumber
        })
        .FirstOrDefaultAsync();

            return stop;
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
