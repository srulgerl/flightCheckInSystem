using DataAccess.Models;

namespace DataAccess.Repositories
{
    public interface IReservationRepository
    {
        List<Reservation> GetReservationsByFlight(int flightId);
        Task<Reservation?> GetBySeatAsync(int flightId, string seatNumber);
        Task AddReservationAsync(Reservation reservation);
        Reservation? GetReservationByPassenger(int passengerId);
        Reservation? GetReservationByPassengerAndFlight(int passengerId, int flightId);


    }
}
