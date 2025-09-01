using System.Net.Http;
using System.Text;
using System.Text.Json;

// === Parallel clients to test seat reservation ===
class Program
{
    static async Task Main()
    {
        using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5000/") };

        // FlightId болон SeatNumber тогтмол байна
        int flightId = 1;
        string seatNumber = "D2";

        // 3 зорчигчийн симуляци
        var tasks = Enumerable.Range(1, 3).Select(async i =>
        {
            var reservation = new
            {
                flightId = flightId,
                passengerId = i,       // өөр зорчигч ID (1,2,3 гэж үзсэн)
                seatNumber = seatNumber
            };

            var json = JsonSerializer.Serialize(reservation);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/reservation", content);
            string result = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Client {i}: {(response.IsSuccessStatusCode ? "✅" : "❌")} {result}");
        });

        await Task.WhenAll(tasks);
    }
}
