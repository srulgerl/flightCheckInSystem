using DataAccess.Models;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    public class ReservationService
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationService(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task<(bool Success, string Message)> CreateReservation(Reservation reservation)
        {
            // Суудал давхар захиалагдсан эсэхийг шалгана
            var exists = await _reservationRepository.GetBySeatAsync(reservation.FlightId, reservation.SeatNumber);
            if (exists != null)
                return (false, "Seat already taken");

            await _reservationRepository.AddReservationAsync(reservation);
            return (true, $"Seat {reservation.SeatNumber} booked successfully");
        }

        public async Task<IEnumerable<Reservation>> GetReservationsByFlight(int flightId)
        {
            return  _reservationRepository.GetReservationsByFlight(flightId);
        }

        public Reservation? GetReservationByPassenger(int passengerId)
        {
            return _reservationRepository.GetReservationByPassenger(passengerId);
        }

        public Reservation? GetReservationByPassengerAndFlight(int passengerId, int flightId)
        {
            return _reservationRepository.GetReservationByPassengerAndFlight(passengerId, flightId);
        }

    }
}
