
namespace BusinessLogic.DTOs
{
    /// <summary>
    /// Захиалгын үр дүнг илэрхийлэх DTO
    /// </summary>
    /// <param name="Success"></param>
    /// <param name="Message"></param>
    /// <param name="FlightId"></param>
    /// <param name="PassengerId"></param>
    /// <param name="SeatNumber"></param>
    public record ReservationResult(
        bool Success,
        string Message,
        int FlightId,
        int PassengerId,
        string SeatNumber
    );
}
