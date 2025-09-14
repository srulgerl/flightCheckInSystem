using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Context;

/// <summary>
/// 
/// </summary>
public class SocketServer
{
    private readonly ApplicationDBContext _db;
    private TcpListener? _listener;

    public SocketServer(ApplicationDBContext db)
    {
        _db = db;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="port"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    public async Task StartAsync(int port, CancellationToken ct = default)
    {
        _listener = new TcpListener(IPAddress.Any, port);
        _listener.Start();
        Console.WriteLine($"[SocketServer] Listening on port {port}");

        try
        {
            while (!ct.IsCancellationRequested)
            {
                if (_listener.Pending())
                {
                    var client = await _listener.AcceptTcpClientAsync(ct);
                    _ = HandleClientAsync(client, ct);
                }
                else
                {
                    // Reduce CPU usage
                    await Task.Delay(100, ct);
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("[SocketServer] Stopping...");
        }
        finally
        {
            _listener.Stop();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="client"></param>
    /// <param name="ct"></param>
    /// <returns></returns>
    private async Task HandleClientAsync(TcpClient client, CancellationToken ct)
    {
        using var c = client;
        using var ns = c.GetStream();

        var buffer = new byte[1024];
        while (!ct.IsCancellationRequested)
        {
            int read = await ns.ReadAsync(buffer.AsMemory(0, buffer.Length), ct);
            if (read <= 0) break;

            string msg = Encoding.UTF8.GetString(buffer, 0, read);
            Console.WriteLine($"[SocketServer] Received: {msg}");

            byte[] response = Encoding.UTF8.GetBytes("ACK\n");
            await ns.WriteAsync(response.AsMemory(0, response.Length), ct);
        }
    }
}
