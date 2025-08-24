using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationDBContext _db;

        public PassengerRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Passenger>> GetPassengersAsync()
        {
            return await _db.Passengers.ToListAsync();
        }

        public async Task<Passenger?> GetByPassportAsync(string passportNumber)
        {
            return await _db.Passengers
                .FirstOrDefaultAsync(p => p.PassportNumber == passportNumber);
        }
        public Passenger? GetPassengerByPassportAndFlight(string passportNumber, int flightId)
        {
            return _db.Passengers
                      .FirstOrDefault(p => p.PassportNumber == passportNumber && p.FlightId == flightId);
        }

    }
}
