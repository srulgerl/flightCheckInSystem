using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public interface IFlightRepository
    {
        /// <summary>  
        /// Retrieves a list of flights.  
        /// </summary>  
        /// <returns>A list of flights.</returns>  
        Task<IEnumerable<Flight>> GetFlights();

        /// <summary>  
        /// Retrieves a flight by its ID.  
        /// </summary>  
        /// <param name="flightId">The ID of the flight to retrieve.</param>  
        /// <returns>The flight with the specified ID.</returns>  
        Task<Flight> GetFlightByIdAsync(int flightId);

        /// <summary>  
        /// Updates an existing flight.  
        /// </summary>  
        /// <param name="flight">The flight to update.</param>  
        /// <returns>The updated flight.</returns>  
        Task UpdateFlightAsync(Flight flight);

    }
}
