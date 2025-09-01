using DataAccess.Models;
using DataAccess.Repositories;

/// <summary>
/// Захиалгын үйлчилгээний класс. Нислэгийн суудал захиалах, захиалгуудыг авах, зорчигчийн захиалгыг авах зэрэг үйлдлүүдийг гүйцэтгэнэ.
/// </summary>
public class ReservationService
{
    private readonly IReservationRepository _reservationRepository;

    /// <summary>
    /// Захиалгын репозиторийг дамжуулан үүсгэнэ.
    /// </summary>
    /// <param name="reservationRepository">Захиалгын репозиторийн интерфейс</param>
    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    /// <summary>
    /// Захиалга үүсгэх. Суудал захиалагдсан эсэхийг шалгаж, захиалга нэмнэ.
    /// </summary>
    /// <param name="reservation">Захиалгын мэдээлэл</param>
    /// <returns>Амжилттай эсэх болон мессеж</returns>
    public async Task<(bool Success, string Message)> CreateReservation(Reservation reservation)
    {
        var exists = await _reservationRepository.GetBySeatAsync(reservation.FlightId, reservation.SeatNumber);
        if (exists != null)
            return (false, "Суудал аль хэдийн захиалагдсан байна");

        await _reservationRepository.AddReservationAsync(reservation);
        return (true, $"Суудал {reservation.SeatNumber} амжилттай захиалагдлаа");
    }

    /// <summary>
    /// Нислэгийн бүх захиалгуудыг авах.
    /// </summary>
    /// <param name="flightId">Нислэгийн дугаар</param>
    /// <returns>Захиалгуудын жагсаалт</returns>
    public async Task<IEnumerable<Reservation>> GetReservationsByFlight(int flightId)
    {
        return await _reservationRepository.GetReservationsByFlight(flightId);
    }

    /// <summary>
    /// Зорчигчийн захиалгыг авах.
    /// </summary>
    /// <param name="passengerId">Зорчигчийн дугаар</param>
    /// <returns>Захиалгын мэдээлэл</returns>
    public async Task<Reservation?> GetReservationByPassenger(int passengerId)
    {
        return await _reservationRepository.GetReservationByPassenger(passengerId);
    }

    /// <summary>
    /// Зорчигч болон нислэгийн захиалгыг авах.
    /// </summary>
    /// <param name="passengerId">Зорчигчийн дугаар</param>
    /// <param name="flightId">Нислэгийн дугаар</param>
    /// <returns>Захиалгын мэдээлэл</returns>
    public async Task<Reservation?> GetReservationByPassengerAndFlight(int passengerId, int flightId)
    {
        return await _reservationRepository.GetReservationByPassengerAndFlight(passengerId, flightId);
    }
}
