using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Context;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;

namespace BusinessLogic.Services
{
    /// <summary>
<<<<<<< HEAD
    /// Manages flight-related operations, including retrieving and updating flight information. Handles exceptions
    /// during these operations.
    /// Нислэгтэй холбоотой үйлдлүүдийг удирддаг, үүнд нислэгийн мэдээллийг авах болон шинэчлэх зэрэг орно. Эдгээр үйлдлүүдийн явцад гарсан алдааг зохицуулдаг.
=======
    /// Service for managing flight operations
>>>>>>> f07a4870a11fd87ff0690f0248ce862eaf16787a
    /// </summary>
    public class FlightService
    {
        private readonly IFlightRepository _repository;
<<<<<<< HEAD
        private readonly ApplicationDBContext _con;
        /// <summary>
        /// Нислэгийн үйлчилгээний шинэ жишээг тодорхой агуулах, нислэгтэй холбоотой өгөгдлийн үйлдлүүдэд хандах боломжийг олгоно.
        /// </summary>
        /// <param name="repository">Provides access to flight-related data operations.</param>
        /// <param name="con">Represents the database context for managing data transactions.</param>
        /// <exception cref="ArgumentNullException">Thrown when either the repository or database context is null during initialization.</exception>
        public FlightService(IFlightRepository repository, ApplicationDBContext con)
=======


        /// <summary>
        /// Constructor for FlightService
        /// </summary>
        /// <param name="repository"></param>
        /// <param name="con"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public FlightService(IFlightRepository repository)
>>>>>>> f07a4870a11fd87ff0690f0248ce862eaf16787a
        {
            _repository = repository;
        }
<<<<<<< HEAD
        /// <summary>
        /// Нислэгийн объектуудын цуглуулгыг репозитороос асинхрон байдлаар авна.
        /// Retrieves a collection of Flight objects asynchronously from the repository.
        /// </summary>
        /// <returns>Нислэгийн IEnumerable-г буцаадаг.</returns>
=======

        /// <summary>
        /// Retrieves all flights
        /// </summary>
        /// <returns></returns>
>>>>>>> f07a4870a11fd87ff0690f0248ce862eaf16787a
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

<<<<<<< HEAD
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
=======
        /// <summary>
        /// Updates the status of a flight
        /// </summary>
        /// <param name="flightId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<bool> UpdateFlightStatus(int flightId, string status)
>>>>>>> f07a4870a11fd87ff0690f0248ce862eaf16787a
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
