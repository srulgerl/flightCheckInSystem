using Microsoft.AspNetCore.SignalR;
using Server.Hubs;
using Server.Notifier.Interfaces;

/// <summary>
/// Provides functionality to broadcast flight status updates using SignalR.
/// </summary>
public class SignalRFlightNotifier : IFlightNotifier
{
    private readonly IHubContext<FlightStatusHub> _hub;

    /// <summary>
    /// Initializes a new instance of the <see cref="SignalRFlightNotifier"/> class.
    /// </summary>
    /// <param name="hub">The SignalR hub context for broadcasting messages.</param>
    public SignalRFlightNotifier(IHubContext<FlightStatusHub> hub)
    {
        _hub = hub;
    }

    /// <summary>
    /// Broadcasts the status update for a specific flight to all connected clients.
    /// </summary>
    /// <param name="flightId">The unique identifier of the flight.</param>
    /// <param name="status">The status message to broadcast.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public Task BroadcastStatusAsync(int flightId, string status)
    {
        return _hub.Clients.All.SendAsync("FlightStatusUpdated", flightId, status);
    }
}
