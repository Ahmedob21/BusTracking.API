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

       
        public async Task DeletArrival(decimal arrivalid)
        {
            try
            {
                var arrival = await _context.Arrivals.FindAsync(arrivalid);

                if (arrival == null)
                {
                    throw new Exception($"Arrival record with ID {arrivalid} not found.");
                }

                _context.Arrivals.Remove(arrival);

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while deleting the Arrival: {ex.Message}");
            }
        }

        public async Task<List<ArrivalModel>> GellAllArrivalsByChildId(decimal childid)
        {
            var arrivals = await _context.Arrivals
                                         .Include(c => c.Child)
                                         .Where(arri => arri.Childid == childid)
                                         .ToListAsync();

            // Map the list of Arrival entities to a list of ArrivalModel instances
            var arrivalModels = arrivals.Select(arri => new ArrivalModel
            {
                Arrivalid=arri.Arrivalid,
                Teacherid = arri.Teacherid,
                Childid = arri.Childid,
                Status = arri.Status,
                Firstname = arri.Child.Firstname,
                Lastname = arri.Child.Lastname
            }).ToList();

            return arrivalModels;
        }

        public async Task UpdateArrival(decimal id,UpdateArrival updatedarrival)
        {
            try
            {
                var arrival = await _context.Arrivals.FindAsync(id);

                if (arrival == null)
                {
                    throw new Exception($"Arrival record with ID {id} not found.");
                }

                arrival.Status = updatedarrival.Status;

                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while updating the arrival: {ex.Message}");
            }
        }
    }
}
