using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BusinessLogic.Services;
using DataAccess.Models;

namespace Server.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class FlightController : ControllerBase
    {
        private readonly FlightService _flightService;
        public FlightController(FlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet("list")]
        public async Task<IActionResult> GetFlights() // Mark method as async
        {
            var flights = (await _flightService.GetFlights()) // Await the Task<IEnumerable<Flight>>
                          .Select(f => new { f.FlightId, f.FlightNumber })
                          .ToList();
            return Ok(flights);
        }

        [HttpGet("status")]
        //
        [HttpPost("updateStatus")]
        public async Task<IActionResult> UpdateFlightAsync(int flight_id) // Mark method as async
        {
            // Fixing CS1061 and CS1002 by correcting the logic and syntax
            var flight = await _flightService.UpdateFlightAsync(flight_id); // Await the Task<Flight>
            if (flight == null)
            {
                return NotFound($"Flight with ID {flight_id} not found.");
            }

            var updatedFlight = new
            {
                flight.Status
            };

            return Ok(updatedFlight);
        }
    }
}
