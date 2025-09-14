using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Manages flight-related operations, including retrieving and updating flight information. Handles exceptions
    /// during these operations.
    /// </summary>
    public class FlightService
    {
        private readonly IFlightRepository _repository;
        private readonly ApplicationDBContext _con;

        /// <summary>
        /// Initializes a new instance of the FlightService class.
        /// </summary>
        /// <param name="repository">Provides access to flight-related data operations.</param>
        /// <param name="con">Represents the database context for managing data transactions.</param>
        /// <exception cref="ArgumentNullException">Thrown when either the repository or database context is null.</exception>
        public FlightService(IFlightRepository repository, ApplicationDBContext con)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _con = con ?? throw new ArgumentNullException(nameof(con));
        }

        /// <summary>
        /// Retrieves a collection of Flight objects asynchronously from the repository.
        /// </summary>
        /// <returns>An IEnumerable of flights.</returns>
        public async Task<IEnumerable<Flight>> GetFlights()
        {
            try
            {
                return await _repository.GetFlights();
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the status of a flight.
        /// </summary>
        /// <param name="flightId">The ID of the flight to update.</param>
        /// <param name="status">The new status to assign.</param>
        /// <returns>True if the update was successful; otherwise, false.</returns>
        public async Task<bool> UpdateFlightStatus(int flightId, string status)
        {
            var flight = await _repository.GetFlightByIdAsync(flightId);
            if (flight == null)
                return false;

            if (Enum.TryParse<FlightStatus>(status, out var parsedStatus))
            {
                flight.Status = parsedStatus;
                await _repository.UpdateFlightAsync(flight);
                return true;
            }

            return false;
        }

        // Optional: Restore these methods if needed later
        /*
        public async Task<Flight?> GetFlightByIdAsync(int flightId)
        {
            try
            {
                return await _repository.GetFlightByIdAsync(flightId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> AddFlightAsync(Flight flight)
        {
            try
            {
                return await _repository.AddFlightAsync(flight);
            }
            catch (Exception)
            {
                throw;
            }
        }
        */
    }
}
