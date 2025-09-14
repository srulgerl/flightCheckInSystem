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

        /// <summary>
        /// Gets all reservations for a specific flight.
        /// </summary>
        /// <param name="flightId">The ID of the flight.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>A collection of reservations for the flight.</returns>
        public async Task<IEnumerable<Reservation>> GetReservationsByFlight(int flightId, CancellationToken ct = default)
        {
            // No tracking needed for read
            var list = await _db.Reservations
                                .AsNoTracking()
                                .Where(r => r.FlightId == flightId)
                                .ToListAsync(ct);
            return list;
        }

        /// <summary>
        /// Gets a reservation by seat number on a specific flight.
        /// </summary>
        /// <param name="flightId">The ID of the flight.</param>
        /// <param name="seatNumber">The seat number.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>The reservation for the seat, or null if not found.</returns>
        public async Task<Reservation?> GetReservationBySeatAsync(int flightId, string seatNumber, CancellationToken ct = default)
        {
            return await _db.Reservations
                            .FirstOrDefaultAsync(r => r.FlightId == flightId && r.SeatNumber == seatNumber, ct);
        }

        /// <summary>
        /// Checks if a seat is taken on a specific flight.
        /// </summary>
        /// <param name="flightId">The ID of the flight.</param>
        /// <param name="seatNumber">The seat number.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>True if the seat is taken, otherwise false.</returns>
        public async Task<bool> IsSeatTakenAsync(int flightId, string seatNumber, CancellationToken ct = default)
        {
            return await _db.Reservations
                            .AsNoTracking()
                            .AnyAsync(r => r.FlightId == flightId && r.SeatNumber == seatNumber, ct);
        }

        /// <summary>
        /// Adds a new reservation.
        /// </summary>
        /// <param name="reservation">The reservation to add.</param>
        /// <param name="ct">Cancellation token.</param>
        public async Task AddReservationAsync(Reservation reservation, CancellationToken ct = default)
        {
            await _db.Reservations.AddAsync(reservation, ct);
            await _db.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Updates an existing reservation.
        /// </summary>
        /// <param name="reservation">The reservation to update.</param>
        /// <param name="ct">Cancellation token.</param>
        public async Task UpdateReservationAsync(Reservation reservation, CancellationToken ct = default)
        {
            // Attach and mark as modified if not tracked
            _db.Attach(reservation);
            _db.Entry(reservation).State = EntityState.Modified;
            await _db.SaveChangesAsync(ct);
        }

        /// <summary>
        /// Gets a reservation for a specific passenger.
        /// </summary>
        /// <param name="passengerId">The ID of the passenger.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>The reservation for the passenger, or null if not found.</returns>
        public async Task<Reservation?> GetReservationByPassenger(int passengerId, CancellationToken ct = default)
        {
            return await _db.Reservations
                            .AsNoTracking()
                            .FirstOrDefaultAsync(r => r.PassengerId == passengerId, ct);
        }

        /// <summary>
        /// Gets a reservation for a specific passenger on a specific flight.
        /// </summary>
        /// <param name="passengerId">The ID of the passenger.</param>
        /// <param name="flightId">The ID of the flight.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>The reservation for the passenger on the flight, or null if not found.</returns>
        public async Task<Reservation?> GetReservationByPassengerAndFlight(int passengerId, int flightId, CancellationToken ct = default)
        {
            return await _db.Reservations
                            .FirstOrDefaultAsync(r => r.PassengerId == passengerId && r.FlightId == flightId, ct);
        }
    }
}
