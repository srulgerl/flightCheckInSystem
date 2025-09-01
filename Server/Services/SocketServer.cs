using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;

public class SocketServer
{
    private readonly ApplicationDBContext _db;

    public SocketServer(ApplicationDBContext db)
    {
        _db = db;
    }

    public async Task StartAsync(int port)
    {
        var listener = new TcpListener(IPAddress.Any, port);
        listener.Start();
        Console.WriteLine($"[SocketServer] Listening on port {port}...");

        while (true)
        {
            var client = await listener.AcceptTcpClientAsync();
            _ = HandleClientAsync(client);
        }
    }

    private async Task HandleClientAsync(TcpClient client)
    {
        Console.WriteLine("[SocketServer] New client connected!");
        using var stream = client.GetStream();

        byte[] buffer = new byte[1024];
        int bytesRead = await stream.ReadAsync(buffer, 0, buffer.Length);
        string request = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        Console.WriteLine($"[SocketServer] Received: {request}");

        // Жишээ логик: зорчигч хайх
        string response;
        var passenger = _db.Passengers.FirstOrDefault(p => p.PassportNumber == request);
        if (passenger != null)
            response = $"PASSENGER_FOUND:{passenger.Name}";
        else
            response = "PASSENGER_NOT_FOUND";

        byte[] responseBytes = Encoding.UTF8.GetBytes(response);
        await stream.WriteAsync(responseBytes, 0, responseBytes.Length);

        client.Close();
    }
}
