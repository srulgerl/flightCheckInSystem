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

        // GET api/passenger
        [HttpGet]
        public async Task<IActionResult> GetPassengers()
        {
            var passengers = await _passengerService.GetPassengers();
            return Ok(passengers);
        }

        // GET api/passenger/{flightId}/{passportNumber}
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

        [HttpGet("{flightId}/{passportNumber}")]
        public async Task<IActionResult> GetPassengerByFlightAndPassport(int flightId, string passportNumber)
        {
            var passenger = await _passengerService.GetPassengerByPassportAndFlight(passportNumber, flightId);
            if (passenger == null)
                return NotFound("Энэ зорчигч энэ нислэгт бүртгэгдээгүй");

            return Ok(new
            {
                passenger.PassengerId,
                passenger.Name,
                passenger.PassportNumber
            });
        }

    }
}
