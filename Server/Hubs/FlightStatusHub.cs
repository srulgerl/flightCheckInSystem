using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

public class FlightStatusHub : Hub
{

    public override async Task OnConnectedAsync()
    {
        Console.WriteLine($"Client connected: {Context.ConnectionId}");
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        Console.WriteLine($"Client disconnected: {Context.ConnectionId}, Reason: {exception?.Message}");
        await base.OnDisconnectedAsync(exception);
    }
    /// <summary>
    /// Sends a flight status update to all connected clients.
    /// </summary>
    /// <param name="flightId"></param>
    /// <param name="status"></param>
    /// <returns></returns>
    public async Task SendStatusUpdate(int flightId, string status)
    {
        await Clients.All.SendAsync("FlightStatusUpdated", flightId, status);
    }
}
