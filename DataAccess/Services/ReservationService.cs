using DataAccess.Models;
using DataAccess.Repositories;

public class ReservationService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    public async Task<(bool Success, string Message)> CreateReservation(Reservation reservation)
    {
        var exists = await _reservationRepository.GetBySeatAsync(reservation.FlightId, reservation.SeatNumber);
        if (exists != null)
            return (false, "Seat already taken");

        await _reservationRepository.AddReservationAsync(reservation);
        return (true, $"Seat {reservation.SeatNumber} booked successfully");
    }

    public async Task<IEnumerable<Reservation>> GetReservationsByFlight(int flightId)
    {
        return await _reservationRepository.GetReservationsByFlight(flightId);
    }

    public async Task<Reservation?> GetReservationByPassenger(int passengerId)
    {
        return await _reservationRepository.GetReservationByPassenger(passengerId);
    }

    public async Task<Reservation?> GetReservationByPassengerAndFlight(int passengerId, int flightId)
    {
        return await _reservationRepository.GetReservationByPassengerAndFlight(passengerId, flightId);
    }
}
