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
            var location = await _context.Buslocations
                .Include(bus => bus.Bus)
                .Where(bus => bus.BusId == busId)
                .OrderByDescending(bus => bus.Adate)
                .FirstOrDefaultAsync();

            if (location == null)
            {
                // Return default location with Latitude and Longitude set to default values
                return new AllBusesLocation
                {
                    Busnumber = _context.Buses.FirstOrDefault(b => b.Busid == busId)?.Busnumber ?? "Unknown Bus", // Get the bus number based on busId
                    Latitude = 31.9596M,            // Default latitude as decimal
                    Longitude = 35.8494M,           // Default longitude as decimal
                    Adate = DateTime.Now,           // Set to the current date/time
                    BusId = busId                   // Bus ID for reference
                };
            }

            return new AllBusesLocation
            {
                Busnumber = location.Bus.Busnumber,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Adate = location.Adate,
                BusId = location.BusId
            };
        }

        public async Task<IEnumerable<AllBusesLocation>> GetAllBusesLocations()
        {
            var locations = await _context.Buslocations.Include(bus => bus.Bus).ToListAsync();

            if (!locations.Any())
            {
                // Return default location if no locations exist
                return _context.Buses.Select(bus => new AllBusesLocation
                {
                    Busnumber = bus.Busnumber,
                    Latitude = 31.9596M,            // Default latitude as decimal
                    Longitude = 35.8494M,           // Default longitude as decimal
                    Adate = DateTime.Now,           // Default date
                    BusId = bus.Busid               // Bus ID from bus table
                }).ToList();
            }

            return locations.Select(location => new AllBusesLocation
            {
                Busnumber = location.Bus.Busnumber,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Adate = location.Adate,
                BusId = location.BusId
            }).ToList();
        }


        public async Task UpdateBusLocation(UpdateBusLocation busLocationDto)
        {
            var existingLocation = await _context.Buslocations.FirstOrDefaultAsync(b => b.BusId == busLocationDto.BusId);

            if (existingLocation != null)
            {
               
                existingLocation.Latitude = busLocationDto.Latitude;
                existingLocation.Longitude = busLocationDto.Longitude;
                existingLocation.Adate = busLocationDto.Adate ?? DateTime.Now;
            }
            else
            {
               
                var newBusLocation = new Buslocation
                {
                    BusId = busLocationDto.BusId,
                    Latitude = busLocationDto.Latitude,
                    Longitude = busLocationDto.Longitude,
                    Adate = busLocationDto.Adate ?? DateTime.Now
                };

                _context.Buslocations.Add(newBusLocation);
            }

            await _context.SaveChangesAsync();
        }


        public async Task<AllBusesLocation> GetBusLocationByTeacherId(decimal teacherId)
        {
            var location = await _context.Buslocations
                .Include(bus => bus.Bus)
                .Where(bus => bus.Bus.Teacherid == teacherId)
                .OrderByDescending(bus => bus.Adate)
                .FirstOrDefaultAsync();

            if (location == null)
            {
                // Return default location if no location exists for the teacher's bus
                var bus = await _context.Buses.FirstOrDefaultAsync(b => b.Teacherid == teacherId);
                return new AllBusesLocation
                {
                    Busnumber = bus?.Busnumber ?? "Unknown Bus", // Get the bus number based on teacherId
                    Latitude = 31.9596M,            // Default latitude as decimal
                    Longitude = 35.8494M,           // Default longitude as decimal
                    Adate = DateTime.Now,           // Set to the current date/time
                    BusId = bus?.Busid ?? 0         // Bus ID from bus table or 0 if not found
                };
            }

            return new AllBusesLocation
            {
                Busnumber = location.Bus.Busnumber,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Adate = location.Adate,
                BusId = location.BusId
            };
        }


        public async Task<AllBusesLocation> GetBusLocationByDriverId(decimal driverId)
        {
            var location = await _context.Buslocations
                .Include(bus => bus.Bus)
                .Where(bus => bus.Bus.Driverid == driverId)
                .OrderByDescending(bus => bus.Adate)
                .FirstOrDefaultAsync();

            if (location == null)
            {
                // Return default location if no location exists for the driver's bus
                var bus = await _context.Buses.FirstOrDefaultAsync(b => b.Driverid == driverId);
                return new AllBusesLocation
                {
                    Busnumber = bus?.Busnumber ?? "Unknown Bus", // Get the bus number based on driverId
                    Latitude = 31.9596M,            // Default latitude as decimal
                    Longitude = 35.8494M,           // Default longitude as decimal
                    Adate = DateTime.Now,           // Set to the current date/time
                    BusId = bus?.Busid ?? 0         // Bus ID from bus table or 0 if not found
                };
            }

            return new AllBusesLocation
            {
                Busnumber = location.Bus.Busnumber,
                Latitude = location.Latitude,
                Longitude = location.Longitude,
                Adate = location.Adate,
                BusId = location.BusId
            };
        }


        public async Task<AllBusesLocation> GetBusLocationForParent(decimal parentId)
        {
            var busId = await _context.Children
                .Where(child => child.Parentid == parentId)
                .Select(child => child.Busid)
                .FirstOrDefaultAsync();

            if (busId == default)
            {
                return null;
            }

            var latestLocation = await _context.Buslocations
                .Include(loc => loc.Bus)
                .Where(loc => loc.BusId == busId)
                .OrderByDescending(loc => loc.Adate)
                .FirstOrDefaultAsync();

            if (latestLocation == null)
            {
                // Return default location if no location exists for the bus
                var bus = await _context.Buses.FirstOrDefaultAsync(b => b.Busid == busId);
                return new AllBusesLocation
                {
                    Busnumber = bus?.Busnumber ?? "Unknown Bus", // Get the bus number based on busId
                    Latitude = 31.9596M,            // Default latitude as decimal
                    Longitude = 35.8494M,           // Default longitude as decimal
                    Adate = DateTime.Now,           // Set to the current date/time
                    BusId = busId                   // Bus ID for reference
                };
            }

            return new AllBusesLocation
            {
                Busnumber = latestLocation.Bus.Busnumber,
                Latitude = latestLocation.Latitude,
                Longitude = latestLocation.Longitude,
                Adate = latestLocation.Adate,
                BusId = latestLocation.BusId
            };
        }



    }
}
