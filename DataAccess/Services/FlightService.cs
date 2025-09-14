using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Service for managing flight operations
    /// </summary>
    public class FlightService
    {
        private readonly IFlightRepository _repository;

        /// <summary>
        /// Constructor for FlightService
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="con"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FlightService(IFlightRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves all flights
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Flight>> GetFlights()
        {
            try
            {
                return await _repository.GetFlights();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        /// <summary>
        /// Updates the status of a flight
        /// </summary>
        /// <param name="flightId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<bool> UpdateFlightStatus(int flightId, string status)
        {
            var flight = await _repository.GetFlightByIdAsync(flightId);
            if (flight == null) return false;

            if (Enum.TryParse<FlightStatus>(status, out var parsedStatus))
            {
                flight.Status = parsedStatus;
                await _repository.UpdateFlightAsync(flight);

                return true;
            }

            return false;
        }
    }
    
}
