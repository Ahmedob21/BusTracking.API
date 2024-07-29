using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.IRepository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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

        public async Task CreateStop(Stop stop)
        {
           _context.Add(stop);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStop(int stopid)
        {
            var stop = await _context.Stops.FindAsync(stopid);
            if (stop != null)
            {
                _context.Stops.Remove(stop);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Stop>> GetAllStops()
        {
            return await _context.Stops.ToListAsync();
        }

        public async Task<Stop> GetStopById(int stopid)
        {
            return await _context.Stops.FindAsync(stopid);
        }

        public async Task UpdateStop(Stop stop)
        {
            _context.Stops.Update(stop);
            await _context.SaveChangesAsync();
        }
    }
}
