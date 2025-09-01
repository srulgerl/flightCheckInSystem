using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BusinessLogic.Services;
using DataAccess.Models;
using Microsoft.AspNetCore.SignalR;

namespace Server.Controller
{
    /// <summary>
    /// Controller for managing flight-related endpoints
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly FlightService _flightService;
        private readonly IHubContext<FlightStatusHub> _hubContext;

        /// <summary>
        /// Constructor for FlightController
        /// </summary>
        /// <param name="flightService"></param>
        /// <param name="hubContext"></param>
        public FlightController(FlightService flightService, IHubContext<FlightStatusHub> hubContext)
        {
            _flightService = flightService;
            _hubContext = hubContext;

        }

        /// <summary>
        /// Retrieves all flights
        /// </summary>
        /// <returns></returns>
        [HttpGet("list")]
        public async Task<IActionResult> GetFlights() // Mark method as async
        {
            var flights = (await _flightService.GetFlights()) // Await the Task<IEnumerable<Flight>>
                          .Select(f => new { f.FlightId, f.FlightNumber, Status = f.Status.ToString() })
                          .ToList();
            return Ok(flights);
        }

        /// <summary>
        /// Updates the status of a flight
        /// </summary>
        /// <param name="flightId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        [HttpPost("updateStatus")]
        public async Task<IActionResult> UpdateStatus(int flightId, string status)
        {
            var success = await _flightService.UpdateFlightStatus(flightId, status);
            await _hubContext.Clients.All.SendAsync("FlightStatusUpdated", flightId, status);

            if (!success) return BadRequest("Status update failed");

            Console.WriteLine($"Broadcasting event: {flightId} -> {status}");

            return Ok("Status updated");
        }

    }
}
