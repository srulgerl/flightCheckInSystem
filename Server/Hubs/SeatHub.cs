using BusinessLogic.DTOs;
using Microsoft.AspNetCore.SignalR;

namespace Server.Hubs
{
    public class SeatHub : Hub
    {
        /// <summary>
        /// Called when a client connects to the hub.
        /// </summary>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public override Task OnConnectedAsync()
        {
            Console.WriteLine($"[SeatHub] Connected: {Context.ConnectionId}");
            return base.OnConnectedAsync();
        }

        /// <summary>
        /// Notifies all clients that a seat has been assigned.
        /// </summary>
        /// <param name="seat">The seat assignment details.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public Task NotifySeatAssigned(SeatDto seat)
            => Clients.All.SendAsync("SeatAssigned", seat);
    }
}
