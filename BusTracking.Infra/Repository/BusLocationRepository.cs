using BusTracking.Core.Data;
using BusTracking.Core.DTO;
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
        public async Task<AllBusesLocation> GetLatestLocation(decimal busId)
        {
            var Locations = await _context.Buslocations.Include(bus=>bus.Bus).Where(bus => bus.BusId == busId).SingleOrDefaultAsync();
            return new AllBusesLocation
            {
                Busnumber = Locations.Bus.Busnumber,
                Latitude = Locations.Latitude,
                Longitude = Locations.Longitude,
                Adate = Locations.Adate,
                BusId = Locations.BusId
            };

        }
        public async Task<IEnumerable<AllBusesLocation>> GetAllBusesLocations()
        {
            var locations = await _context.Buslocations.Include(bus => bus.Bus).ToListAsync();

            return locations.Select(location => new AllBusesLocation
            {
                Busnumber = location.Bus.Busnumber,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Adate = location.Adate,
                BusId = location.BusId
            }).ToList();
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

        public async Task<AllBusesLocation> GetBusLocationByTeacherId(decimal teacherId)
        {
            var busCount = await _context.Buslocations.CountAsync(bus => bus.Bus.Teacherid == teacherId);

            if (busCount > 1)
            {
                throw new InvalidOperationException("The teacher is associated with more than one bus.");
            }

            var result = await _context.Buslocations
                .Where(bus => bus.Bus.Teacherid == teacherId)
                .Select(bus => new AllBusesLocation
                {
                    Busnumber = bus.Bus.Busnumber,
                    Latitude = bus.Latitude,
                    Longitude = bus.Longitude,
                    Adate = bus.Adate,
                    BusId = bus.BusId
                })
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<AllBusesLocation> GetBusLocationByDriverId(decimal driverId)
        {
            var busCount = await _context.Buslocations.CountAsync(bus => bus.Bus.Driverid == driverId);

            if (busCount > 1)
            {
                throw new InvalidOperationException("The teacher is associated with more than one bus.");
            }

            var result = await _context.Buslocations
                .Where(bus => bus.Bus.Driverid == driverId)
                .Select(bus => new AllBusesLocation
                {
                    Busnumber = bus.Bus.Busnumber,
                    Latitude = bus.Latitude,
                    Longitude = bus.Longitude,
                    Adate = bus.Adate,
                    BusId = bus.BusId
                })
                .SingleOrDefaultAsync();

            return result;
        }

        public async Task<AllBusesLocation> GetBusLocationForParent(decimal parentId)
        {
            // Get the bus ID associated with the parent's children
            var busId = await _context.Children
                                       .Where(child => child.Parentid == parentId)
                                       .Select(child => child.Busid)
                                       .FirstOrDefaultAsync();

            // Handle the case where no bus ID is found
            if (busId == default)
            {
                return null;
            }

            // Get the latest bus location for the found busId
            var latestLocation = await _context.Buslocations
                                               .Include(loc => loc.Bus)
                                               .Where(loc => loc.BusId == busId)
                                               .OrderByDescending(loc => loc.Adate)
                                               .FirstOrDefaultAsync();

            // Handle the case where no location is found
            if (latestLocation == null)
            {
                throw new InvalidOperationException("No bus location found for the given parent ID.");
            }

            // Return the latest location mapped to the DTO
            return new AllBusesLocation
            {
                BusId = latestLocation.BusId,
                Busnumber = latestLocation.Bus.Busnumber,
                Latitude = latestLocation.Latitude,
                Longitude = latestLocation.Longitude,
                Adate = latestLocation.Adate
            };
        }

    }
}
