using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using BusinessLogic.Services;

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
    }
}
