using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

public class SocketServer
{
    private readonly ApplicationDBContext _db;

    public SocketServer(ApplicationDBContext db)
    {
        _db = db;
    }

    public async Task StartAsync(int port = 6000)
    {
        var listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"[SocketServer] Listening on port {port}...");

        while (true)
        {
            var client = await listener.AcceptTcpClientAsync();
            _ = HandleClientAsync(client); // fire & forget
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        using var stream = client.GetStream();
        var buffer = new byte[1024];
        var bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        var request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        Console.WriteLine($"[SocketServer] Received: {request}");

        // Жишээ: "BOOK|FL123|P123456|12A"
        var parts = request.Split('|');
        if (parts.Length == 4 && parts[0] == "BOOK")
        {
            var flightNumber = parts[1];
            var passport = parts[2];
            var seat = parts[3];

            var flight = await _db.Flights.FirstOrDefaultAsync(f => f.FlightNumber == flightNumber);
            var passenger = await _db.Passengers.FirstOrDefaultAsync(p => p.PassportNumber == passport);

            if (flight == null || passenger == null)
            {
                await SendAsync(stream, "ERROR|Flight or Passenger not found");
                return;
            }

            // Давхар оноолтоос хамгаалах (Transaction)
            var existing = await _db.Reservations
                .FirstOrDefaultAsync(r => r.FlightId == flight.FlightId && r.SeatNumber == seat);

            if (existing != null)
            {
                await SendAsync(stream, "ERROR|Seat already taken");
            }
            else
            {
                var res = new Reservation
                {
                    FlightId = flight.FlightId,
                    PassengerId = passenger.PassengerId,
                    SeatNumber = seat
                };
                _db.Reservations.Add(res);
                await _db.SaveChangesAsync();

                await SendAsync(stream, $"OK|Seat {seat} booked for {passenger.Name}");
            }
        }
        else
        {
            await SendAsync(stream, "ERROR|Invalid command");
        }
    }

    private async Task SendAsync(NetworkStream stream, string message)
    {
        var bytes = Encoding.UTF8.GetBytes(message);
        await stream.WriteAsync(bytes, 0, bytes.Length);
    }
}
