using DataAccess.Models;

namespace DataAccess.Repositories

    /// <summary>
    /// Захиалгын мэдээлэлтэй ажиллах repository интерфэйс.
    /// Энэ интерфэйс нь тухайн нислэгийн захиалгуудыг авах, суудлын мэдээллээр захиалга хайх,
    /// шинэ захиалга нэмэх, зорчигчоор болон нислэгээр захиалгын мэдээлэл авах функцүүдийг тодорхойлдог.
    /// </summary>

    public interface IReservationRepository
    {
        Task<List<Reservation>> GetReservationsByFlight(int flightId);
        Task<Reservation?> GetBySeatAsync(int flightId, string seatNumber);
        Task AddReservationAsync(Reservation reservation);
        Task<Reservation?> GetReservationByPassenger(int passengerId);
        Task<Reservation?> GetReservationByPassengerAndFlight(int passengerId, int flightId);


    }
}
