using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    public class FlightService
    {
        private readonly IFlightRepository _repository;
        private readonly ApplicationDBContext _con;

        public FlightService(IFlightRepository repository, ApplicationDBContext con)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _con = con ?? throw new ArgumentNullException(nameof(con));
        }

        public async Task<IEnumerable<Flight>> GetFlights()
        {
            try
            {
                return await _repository.GetFlights();
            }
            catch (Exception ex)
            {
                // Optionally log the exception
                Console.WriteLine("Error: "+ ex);
                throw;
            }
        }

        //public async Task<Flight?> GetFlightByIdAsync(int flightId)
        //{
        //    try
        //    {
        //        return await _repository.GetFlightByIdAsync(flightId);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Optionally log the exception
        //        throw;
        //    }
        //}

        //public async Task<bool> AddFlightAsync(Flight flight)
        //{
        //    try
        //    {
        //        return await _repository.AddFlightAsync(flight);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Optionally log the exception
        //        throw;
        //    }
        //}

        public async Task<Flight> UpdateFlightAsync(int flight_id)
        {
            try
            {
                return await _repository.UpdateFlightAsync(flight_id);
            }
            catch (Exception ex)
            {
                // Optionally log the exception
                Console.WriteLine("Error: " + ex);
                throw; // Ensure the exception is rethrown to maintain the method's contract
            }
        }

        //public async Task<bool> DeleteFlightAsync(int flightId)
        //{
        //    try
        //    {
        //        return await _repository.DeleteFlightAsync(flightId);
        //    }
        //    catch (Exception ex)
        //    {
        //        // Optionally log the exception
        //        throw;
        //    }

    }
}
