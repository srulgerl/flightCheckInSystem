namespace BusinessLogic.DTOs
{
    /// <summary>
    /// Data Transfer Object for Seat assignment information
    /// </summary>
    public class SeatDto
    {
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public string PassengerName { get; set; } = "";
        public string SeatNumber { get; set; } = "";   // ж: "A3"
        public DateTime AssignedAtUtc { get; set; } = DateTime.UtcNow;
    }
}
