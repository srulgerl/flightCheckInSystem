using DataAccess.Models;

namespace BusinessLogic.Services.Interfaces
{
    interface IPassengerService
    {
        /// <summary>
        /// Retrieves a list of passengers.
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Passenger>> GetPassengers();

        /// <summary>
        /// Retrieves a passenger by their passport number.
        /// </summary>
        /// <param name="passengerId"></param>
        /// <returns></returns>
        Task<Passenger> GetPassengerByIdAsync(int passengerId);

        /// <summary>
        /// Retrieves a passenger by their passport number.
        /// </summary>
        /// <param name="passenger"></param>
        /// <returns></returns>
        Task UpdatePassengerAsync(Passenger passenger);
    }
}
