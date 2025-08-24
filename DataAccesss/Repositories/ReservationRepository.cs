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

        public List<Reservation> GetReservationsByFlight(int flightId)
        {
            return _db.Reservations.Where(r => r.FlightId == flightId).ToList();
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

        public Reservation? GetReservationByPassenger(int passengerId)
        {
            return _db.Reservations.FirstOrDefault(r => r.PassengerId == passengerId);
        }

        public Reservation? GetReservationByPassengerAndFlight(int passengerId, int flightId)
        {
            return _db.Reservations
                      .FirstOrDefault(r => r.PassengerId == passengerId && r.FlightId == flightId);
        }

    }
}
