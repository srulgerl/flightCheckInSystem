using System.Net.Sockets;
using System.Text;

class Client1
{
    static async Task Main()
    {
        using var client = new TcpClient();
        await client.ConnectAsync("127.0.0.1", 6000);

        var stream = client.GetStream();
        var message = "BOOK|FL123|P123456|12A";  // FlightNumber | Passport | Seat
        var bytes = Encoding.UTF8.GetBytes(message);

        await stream.WriteAsync(bytes, 0, bytes.Length);

        var buffer = new byte[1024];
        var read = await stream.ReadAsync(buffer, 0, buffer.Length);
        var response = Encoding.UTF8.GetString(buffer, 0, read);

        Console.WriteLine($"Server response: {response}");
    }
}
