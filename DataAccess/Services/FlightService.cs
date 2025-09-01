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
    /// <summary>
    /// Manages flight-related operations, including retrieving and updating flight information. Handles exceptions
    /// during these operations.
    /// Нислэгтэй холбоотой үйлдлүүдийг удирддаг, үүнд нислэгийн мэдээллийг авах болон шинэчлэх зэрэг орно. Эдгээр үйлдлүүдийн явцад гарсан алдааг зохицуулдаг.
    /// </summary>
    public class FlightService
    {
        private readonly IFlightRepository _repository;
        private readonly ApplicationDBContext _con;
        /// <summary>
        /// Нислэгийн үйлчилгээний шинэ жишээг тодорхой агуулах, нислэгтэй холбоотой өгөгдлийн үйлдлүүдэд хандах боломжийг олгоно.
        /// </summary>
        /// <param name="repository">Provides access to flight-related data operations.</param>
        /// <param name="con">Represents the database context for managing data transactions.</param>
        /// <exception cref="ArgumentNullException">Thrown when either the repository or database context is null during initialization.</exception>
        public FlightService(IFlightRepository repository, ApplicationDBContext con)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
            _con = con ?? throw new ArgumentNullException(nameof(con));
        }
        /// <summary>
        /// Нислэгийн объектуудын цуглуулгыг репозитороос асинхрон байдлаар авна.
        /// Retrieves a collection of Flight objects asynchronously from the repository.
        /// </summary>
        /// <returns>Нислэгийн IEnumerable-г буцаадаг.</returns>
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
        /// <summary>
        /// Өгөгдсөн нислэгийн дугаараар нислэгийн бичлэгийг шинэчилж, шинэчилсэн нислэгийн мэдээллийг буцаана.
        /// </summary>
        /// <param name="flight_id">Тухайн нислэгийн бичлэгийг хайж, шинэчлэхэд ашиглах дугаар.</param>
        /// <returns>Шинэчилсэн нислэгийн мэдээллийг буцаана.</returns>
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
