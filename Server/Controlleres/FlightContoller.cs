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
    public class FlightContoller : ControllerBase
    {
        private readonly FlightService _flightService;
        public FlightContoller(FlightService flightService)
        {
            _flightService = flightService;
        }

        [HttpGet]
        [Route("GetFlight")]
        public IActionResult GetFlight()
        {
            try
            {
                var flights = _flightService.GetFlights();
                return Ok(flights);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
