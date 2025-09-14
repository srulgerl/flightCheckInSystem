// Server/Controllers/ReservationController.cs (эсвэл байгаа controller)
using BusinessLogic.DTOs;
using DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Server.Notifier.Interfaces;

namespace Server.Controllers
{

    [ApiController]
    [Route("api/reservation")]
    public class ReservationController : ControllerBase
    {
        private readonly ReservationService _reservationService;
        private readonly ISeatNotifier _seatNotifier; // SignalR-аа энд

        public ReservationController(ReservationService reservationService, ISeatNotifier seatNotifier)
        {
            _reservationService = reservationService;
            _seatNotifier = seatNotifier;
        }

        /// <summary>
        /// Creates or updates a reservation for a passenger on a specific flight and broadcasts the seat assignment in real-time.
        /// </summary>
        /// <param name="req">The reservation creation request.</param>
        /// <param name="ct">Cancellation token.</param>
        /// <returns>An IActionResult indicating the result of the operation.</returns>
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateReservationRequest req, CancellationToken ct)
        {
            var reservation = new Reservation
            {
                FlightId = req.FlightId,
                PassengerId = req.PassengerId,
                SeatNumber = req.SeatNumber,
                Flight = new Flight()
            };

            var result = await _reservationService.CreateOrUpdateReservationAsync(reservation, ct);
            if (!result.Success) return BadRequest(result.Message);

            // ✅ Реал-тайм broadcast-оо энд хийнэ (service нь цэвэр үлдэнэ)
            await _seatNotifier.BroadcastSeatAssignedAsync(new SeatDto
            {
                FlightId = result.FlightId,
                PassengerId = result.PassengerId,
                PassengerName = "", // хүсвэл populate
                SeatNumber = result.SeatNumber,
                AssignedAtUtc = DateTime.UtcNow
            });

            return Ok(new { message = result.Message });
        }

        /// <summary>
        /// Gets all reservations for a specific flight.
        /// </summary>
        /// <param name="flightId">The ID of the flight.</param>
        /// <returns>A collection of reservations for the specified flight.</returns>
        [HttpGet("{flightId}")]
        public async Task<IActionResult> GetReservationsByFlight(int flightId)
        {
            var reservations = await _reservationService.GetReservationsByFlight(flightId);
            return Ok(reservations);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flightId"></param>
        /// <returns></returns>
        [HttpGet("flight/{flightId}/seats")]
        public async Task<IActionResult> GetReservedSeats(int flightId) 
        {
            var reservations = await _reservationService.GetReservationsByFlight(flightId); 
            var seats = reservations.Select(r => r.SeatNumber).ToList(); 

            return Ok(seats);
        }
    }

}
