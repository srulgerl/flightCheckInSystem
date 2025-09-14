using BusinessLogic.DTOs;
using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PassengerController : ControllerBase
    {
        private readonly PassengerService _passengerService;
        private readonly ReservationService _reservationService;

        public PassengerController(PassengerService passengerService, ReservationService reservationService)
        {
            _passengerService = passengerService;
            _reservationService = reservationService;
        }

        /// <summary>
        /// Retrieves all passengers.
        /// </summary>
        /// <returns>A list of all passengers.</returns>
        [HttpGet]
        public async Task<IActionResult> GetPassengers()
        {
            var passengers = await _passengerService.GetPassengers();
            return Ok(passengers);
        }

        /// <summary>
        /// Retrieves a passenger by passport number and flight ID, including seat information if available.
        /// </summary>
        /// <param name="flightId">The ID of the flight.</param>
        /// <param name="passportNumber">The passport number of the passenger.</param>
        /// <returns>The passenger with seat information if found; otherwise, NotFound.</returns>
        [HttpGet("{flightId:int}/{passportNumber}")]
        public async Task<IActionResult> GetPassengerByPassport(int flightId, string passportNumber)
        {
            var passenger = await _passengerService.GetPassengerByPassport(passportNumber);
            if (passenger == null)
                return NotFound("Passenger not found");

            var reservation = await _reservationService.GetReservationByPassengerAndFlight(passenger.PassengerId, flightId);

            var dto = new PassengerWithSeatDto
            {
                PassengerId = passenger.PassengerId,
                Name = passenger.Name,
                PassportNumber = passenger.PassportNumber,
                SeatNumber = reservation?.SeatNumber
            };

            return Ok(dto);
        }
    }
}
