using DataAccess.Models;

namespace DataAccess.Repositories
{
    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservationsByFlight(int flightId);
        Task<Reservation?> GetBySeatAsync(int flightId, string seatNumber);
        Task AddReservationAsync(Reservation reservation);
        Task<Reservation?> GetReservationByPassenger(int passengerId);
        Task<Reservation?> GetReservationByPassengerAndFlight(int passengerId, int flightId);


    }
}
