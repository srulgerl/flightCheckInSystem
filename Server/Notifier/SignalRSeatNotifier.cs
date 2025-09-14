using BusinessLogic.DTOs;
using Microsoft.AspNetCore.SignalR;
using Server.Hubs;
using Server.Notifier.Interfaces;

namespace Server.Notifier
{
    /// <summary>
    /// Notifies clients via SignalR when a seat is assigned.
    /// </summary>
    public class SignalRSeatNotifier : ISeatNotifier
    {
        private readonly IHubContext<SeatHub> _hub;

        public SignalRSeatNotifier(IHubContext<SeatHub> hub)
        {
            _hub = hub;
        }

        /// <summary>
        /// Broadcasts a notification to all clients that a seat has been assigned.
        /// </summary>
        /// <param name="seat">The seat assignment details.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        public Task BroadcastSeatAssignedAsync(SeatDto seat)
        {
            return _hub.Clients.All.SendAsync("SeatAssigned", seat);
        }
    }
}
