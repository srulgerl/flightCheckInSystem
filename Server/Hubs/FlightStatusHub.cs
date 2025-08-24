using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.SignalR;

public class FlightStatusHub : Hub
{
    public async Task UpdateStatus(string flightNumber, string status)
    {
        await Clients.All.SendAsync("StatusUpdated", flightNumber, status);
    }
}
