using DataAccess.Models;

public interface IReservationRepository
{
    /// <summary>
    /// Gets all reservations for a specific flight.
    /// </summary>
    /// <param name="flightId">The ID of the flight.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>A collection of reservations for the flight.</returns>
    Task<IEnumerable<Reservation>> GetReservationsByFlight(int flightId, CancellationToken ct = default);

    /// <summary>
    /// Gets a reservation for a specific passenger.
    /// </summary>
    /// <param name="passengerId">The ID of the passenger.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The reservation for the passenger, or null if not found.</returns>
    Task<Reservation?> GetReservationByPassenger(int passengerId, CancellationToken ct = default);

    /// <summary>
    /// Gets a reservation for a specific passenger on a specific flight.
    /// </summary>
    /// <param name="passengerId">The ID of the passenger.</param>
    /// <param name="flightId">The ID of the flight.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The reservation for the passenger on the flight, or null if not found.</returns>
    Task<Reservation?> GetReservationByPassengerAndFlight(int passengerId, int flightId, CancellationToken ct = default);

    /// <summary>
    /// Gets a reservation by seat number on a specific flight.
    /// </summary>
    /// <param name="flightId">The ID of the flight.</param>
    /// <param name="seatNumber">The seat number.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>The reservation for the seat, or null if not found.</returns>
    Task<Reservation?> GetReservationBySeatAsync(int flightId, string seatNumber, CancellationToken ct = default);

    /// <summary>
    /// Checks if a seat is taken on a specific flight.
    /// </summary>
    /// <param name="flightId">The ID of the flight.</param>
    /// <param name="seatNumber">The seat number.</param>
    /// <param name="ct">Cancellation token.</param>
    /// <returns>True if the seat is taken, otherwise false.</returns>
    Task<bool> IsSeatTakenAsync(int flightId, string seatNumber, CancellationToken ct = default);

    /// <summary>
    /// Adds a new reservation.
    /// </summary>
    /// <param name="reservation">The reservation to add.</param>
    /// <param name="ct">Cancellation token.</param>
    Task AddReservationAsync(Reservation reservation, CancellationToken ct = default);

    /// <summary>
    /// Updates an existing reservation.
    /// </summary>
    /// <param name="reservation">The reservation to update.</param>
    /// <param name="ct">Cancellation token.</param>
    Task UpdateReservationAsync(Reservation reservation, CancellationToken ct = default);
}
