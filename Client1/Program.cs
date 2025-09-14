using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using BusinessLogic.DTOs; 

class Program
{
    /// <summary>
    /// Entry point for the client application.
    /// Fetches passengers and simulates seat reservations for the first three passengers.
    /// </summary>
    /// <returns>Task</returns>
    static async Task Main()
    {
        using var client = new HttpClient { BaseAddress = new Uri("http://localhost:5000/") };

        int flightId = 1;
        string seatNumber = "D4";

        // --- Fetch passengers from API ---
        var passengers = await client.GetFromJsonAsync<List<PassengerDto>>("api/passenger");

        if (passengers == null || passengers.Count < 3)
        {
            return;
        }

        // Simulate reservations for 3 passengers
        var tasks = passengers.Take(3).Select(p => SendReservation(client, flightId, seatNumber, p.PassengerId));

        await Task.WhenAll(tasks);
        Console.ReadLine();
    }

    static async Task SendReservation(HttpClient client, int flightId, string seatNumber, int passengerId)
    {
        try
        {
            var reservation = new
            {
                flightId,
                passengerId,
                seatNumber
            };

            var json = JsonSerializer.Serialize(reservation);
            using var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/reservation", content);
            string result = await response.Content.ReadAsStringAsync();

            Console.WriteLine($"Passenger {passengerId}: {(response.IsSuccessStatusCode ? "✅" : "❌")} {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Passenger {passengerId}: ❌ Exception {ex.Message}");
        }
    }
}
