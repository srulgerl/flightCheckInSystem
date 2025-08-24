using BusinessLogic.DTOs;
using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;

        public ReservationController(ReservationService reservationService)
        {
            _reservationService = reservationService;
        }

        // POST api/reservation
        [HttpPost]
        public async Task<IActionResult> CreateReservation([FromBody] ReservationRequest req)
        {
            if (req == null) return BadRequest("Invalid data");

            var reservation = new Reservation
            {
                FlightId = req.FlightId,
                PassengerId = req.PassengerId,
                SeatNumber = req.SeatNumber
            };

            var result = await _reservationService.CreateReservation(reservation);
            if (!result.Success)
                return BadRequest(result.Message);

            return Ok(result.Message);
        }


        // GET api/reservation/{flightId}
        [HttpGet("{flightId}")]
        public async Task<IActionResult> GetReservationsByFlight(int flightId)
        {
            var reservations = await _reservationService.GetReservationsByFlight(flightId);
            return Ok(reservations);
        }

        [HttpGet("flight/{flightId}/seats")]
        public async Task<IActionResult> GetReservedSeats(int flightId) // Mark the method as async
        {
            var reservations = await _reservationService.GetReservationsByFlight(flightId); // Await the Task
            var seats = reservations.Select(r => r.SeatNumber).ToList(); // Now you can use Select

            return Ok(seats);
        }

    }
}
