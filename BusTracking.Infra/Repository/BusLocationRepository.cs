using BusTracking.Core.Data;
using BusTracking.Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Repository
{
    public class BusLocationRepository : IBusLocationRepository
    {
        private readonly ModelContext _context;

        public BusLocationRepository(ModelContext context)
        {
            _context = context;
        }
        public async Task<Buslocation> GetLatestLocation(int busId)
        {
            return await _context.Buslocations.Where(bus => bus.BusId == busId).OrderByDescending(Cdate => Cdate.Adate).SingleOrDefaultAsync();
        }


        public async Task UpdateBusLocation(Buslocation busLocation)
        {
            var existingLocation = await _context.Buslocations.FirstOrDefaultAsync(b=>b.BusId == busLocation.BusId);


            if (existingLocation != null )
            {
                existingLocation.Latitude = busLocation.Latitude;
                existingLocation.Longitude = busLocation.Longitude;
                existingLocation.Adate = busLocation.Adate ?? DateTime.Now;
            }
            else
            {
                busLocation.Adate = busLocation.Adate ?? DateTime.Now; // Set manually or use current time
                _context.Buslocations.Add(busLocation);
            }
            await _context.SaveChangesAsync();
        }











        }
}
