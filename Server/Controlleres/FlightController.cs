using BusinessLogic.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Server.Hubs;
using BusinessLogic.DTOs;
using Server.Notifier.Interfaces;

[ApiController]
[Route("api/flight")]
public class FlightController : ControllerBase
{
    /// <summary>
    /// Service for managing flight operations.
    /// </summary>
    private readonly FlightService _flightService;

    /// <summary>
    /// Notifier for broadcasting flight status updates in real-time.
    /// </summary>
    private readonly IFlightNotifier _flightNotifier;

    /// <summary>
    /// Initializes a new instance of the <see cref="FlightController"/> class.
    /// </summary>
    /// <param name="svc">The flight service.</param>
    /// <param name="notifier">The flight notifier.</param>
    public FlightController(FlightService svc, IFlightNotifier notifier)
    {
        _flightService = svc;
        _flightNotifier = notifier;
    }

    /// <summary>
    /// Updates the status of a flight and broadcasts the change in real-time.
    /// </summary>
    /// <param name="req">The request containing the flight ID and new status.</param>
    /// <returns>An IActionResult indicating the result of the operation.</returns>
    [HttpPut("status")]
    public async Task<IActionResult> UpdateStatus([FromBody] ChangeStatusRequest req)
    {
        var ok = await _flightService.UpdateFlightStatus(req.FlightId, req.Status);
        if (!ok) return BadRequest("Status update failed");

        // ✅ Реал-тайм broadcast — зөвхөн энд
        await _flightNotifier.BroadcastStatusAsync(req.FlightId, req.Status);
        return Ok("Status updated");
    }

    /// <summary>
    /// Retrieves a list of all flights.
    /// </summary>
    /// <returns>A list of flight DTOs.</returns>
    [HttpGet("list")]
    public async Task<IActionResult> List()
    {
        var flights = await _flightService.GetFlights();
        return Ok(flights.Select(f => new FlightDto
        {
            FlightId = f.FlightId,
            FlightNumber = f.FlightNumber,
            Status = f.Status.ToString(),
            DepartureTime = f.DepartureTime,
            ArrivalTime = f.ArrivalTime,
            DepartureAirport = f.DepartureAirport,
            ArrivalAirport = f.ArrivalAirport
        }));
    }
}
