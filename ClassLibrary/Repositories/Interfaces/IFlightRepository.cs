using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    interface IFlightRepository
    {
        /// <summary>  
        /// Retrieves a list of flights.  
        /// </summary>  
        /// <returns>A list of flights.</returns>  
        Task<IEnumerable<Flight>> GetFlightsAsync();
        /// <summary>  
        /// Retrieves a flight by its ID.  
        /// </summary>  
        /// <param name="flightId">The ID of the flight to retrieve.</param>  
        /// <returns>The flight with the specified ID.</returns>  
        Task<Flight> GetFlightByIdAsync(int flightId);
        /// <summary>  
        /// Adds a new flight.  
        /// </summary>  
        /// <param name="flight">The flight to add.</param>  
        /// <returns>The added flight.</returns>  
        Task<Flight> AddFlightAsync(Flight flight);
        /// <summary>  
        /// Updates an existing flight.  
        /// </summary>  
        /// <param name="flight">The flight to update.</param>  
        /// <returns>The updated flight.</returns>  
        Task<Flight> UpdateFlightAsync(Flight flight);
        /// <summary>  
        /// Deletes a flight by its ID.  
        /// </summary>  
        /// <param name="flightId">The ID of the flight to delete.</param>  
        Task DeleteFlightAsync(int flightId);
    }
}
