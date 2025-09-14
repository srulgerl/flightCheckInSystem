using DataAccess.Models;

namespace BusinessLogic.Services.Interfaces
{
    interface IReservationService
    {
        /// <summary>
        /// Retrieves a list of reservations.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Reservation>> GetReservations();

        /// <summary>
        /// Retrieves a reservation by Id
        /// </summary>
        /// <param name="reservationId"></param>
        /// <returns></returns>
        Task<Reservation> GetReservationByIdAsync(int reservationId);

        /// <summary>
        /// Adds a new reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        Task<Reservation> AddReservationAsync(Reservation reservation);

        /// <summary>
        /// Updates an existing reservation
        /// </summary>
        /// <param name="reservation"></param>
        /// <returns></returns>
        Task UpdateReservationAsync(Reservation reservation);

 
    }
}
