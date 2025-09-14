using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public interface IPassengerRepository
    {
        /// <summary>
        /// Retrieves all passengers asynchronously.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation. The task result contains a collection of passengers.</returns>
        Task<IEnumerable<Passenger>> GetPassengersAsync();

        /// <summary>
        /// Retrieves a passenger by their passport number asynchronously.
        /// </summary>
        /// <param name="passportNumber">The passport number of the passenger.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the passenger if found; otherwise, null.</returns>
        Task<Passenger?> GetByPassportAsync(string passportNumber);

        /// <summary>
        /// Retrieves a passenger by their passport number and flight ID.
        /// </summary>
        /// <param name="passportNumber">The passport number of the passenger.</param>
        /// <param name="flightId">The flight ID associated with the passenger.</param>
        /// <returns>The passenger if found; otherwise, null.</returns>
        Passenger? GetPassengerByPassportAndFlight(string passportNumber, int flightId);
    }
}
