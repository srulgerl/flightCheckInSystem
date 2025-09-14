using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
namespace Server.Hubs
{
    public class FlightStatusHub : Hub
    {
        /// <summary>
        /// Called when a client connects to the hub.
        /// Logs the connection ID to the console.
        /// </summary>
        /// <returns>A task that represents the asynchronous operation.</returns>
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine($"Client connected: {Context.ConnectionId}");
            await base.OnConnectedAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="flightId"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task SendStatusUpdate(int flightId, string status)
        {
            await Clients.All.SendAsync("FlightStatusUpdated", flightId, status);
        }
    }
}
