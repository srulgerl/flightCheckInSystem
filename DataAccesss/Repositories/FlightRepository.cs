using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly ApplicationDBContext _db;

        public FlightRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Retrieves all flights
        /// </summary>
        public async Task<IEnumerable<Flight>> GetFlights()
        {
            return await _db.Flights.ToListAsync();
        }

        /// <summary>
        /// Retrieves a flight by Id
        /// </summary>
        public async Task<Flight> GetFlightByIdAsync(int flightId)
        {
            return await _db.Flights.FirstOrDefaultAsync(f => f.FlightId == flightId);
        }

        /// <summary>
        /// Updates a flight by Id
        /// </summary>
        public async Task UpdateFlightAsync(Flight flight)
        {
            _db.Flights.Update(flight);
            await _db.SaveChangesAsync();
        }
    }
}
