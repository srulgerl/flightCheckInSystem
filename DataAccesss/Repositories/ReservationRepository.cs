using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDBContext _db;

        public ReservationRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        public async Task<List<Reservation>> GetReservationsByFlight(int flightId) // Fixed return type to Task<List<Reservation>>
        {
            return await _db.Reservations
                           .Where(r => r.FlightId == flightId)
                           .ToListAsync();
        }

        public async Task<Reservation?> GetBySeatAsync(int flightId, string seatNumber)
        {
            return await _db.Reservations
                .FirstOrDefaultAsync(r => r.FlightId == flightId && r.SeatNumber == seatNumber);
        }

        public async Task AddReservationAsync(Reservation reservation)
        {
            _db.Reservations.Add(reservation);
            await _db.SaveChangesAsync();
        }

        public async Task<Reservation?> GetReservationByPassenger(int passengerId)
        {
            return await _db.Reservations.FirstOrDefaultAsync(r => r.PassengerId == passengerId);
        }

        public async Task<Reservation?> GetReservationByPassengerAndFlight(int passengerId, int flightId)
        {
            return await _db.Reservations
                      .FirstOrDefaultAsync(r => r.PassengerId == passengerId && r.FlightId == flightId);
        }
    }
}
