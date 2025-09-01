using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Захиалгын мэдээлэлтэй ажиллах repository-ийн хэрэгжилт.
    /// Нислэг, зорчигч, суудлын дугаараар захиалга авах, шинээр захиалга нэмэх зэрэг үйлдлүүдийг агуулна.
    /// </summary>
    public class ReservationRepository : IReservationRepository
    {
        private readonly ApplicationDBContext _db;

        /// <summary>
        /// ReservationRepository-ийн шинэ экземплярыг үүсгэх конструктор.
        /// </summary>
        /// <param name="db">Өгөгдлийн сангийн контекст</param>
        public ReservationRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Тухайн нислэгийн бүх захиалгуудыг буцаана.
        /// </summary>
        /// <param name="flightId">Нислэгийн ID</param>
        /// <returns>Захиалгуудын жагсаалт</returns>
        public async Task<List<Reservation>> GetReservationsByFlight(int flightId)
        {
            return await _db.Reservations
                           .Where(r => r.FlightId == flightId)
                           .ToListAsync();
        }

        /// <summary>
        /// Нислэг болон суудлын дугаараар захиалга хайж олно.
        /// </summary>
        /// <param name="flightId">Нислэгийн ID</param>
        /// <param name="seatNumber">Суудлын дугаар</param>
        /// <returns>Захиалгын мэдээлэл эсвэл null</returns>
        public async Task<Reservation?> GetBySeatAsync(int flightId, string seatNumber)
        {
            return await _db.Reservations
                .FirstOrDefaultAsync(r => r.FlightId == flightId && r.SeatNumber == seatNumber);
        }

        /// <summary>
        /// Шинэ захиалгыг өгөгдлийн санд нэмнэ.
        /// </summary>
        /// <param name="reservation">Нэмэх захиалгын объект</param>
        public async Task AddReservationAsync(Reservation reservation)
        {
            _db.Reservations.Add(reservation);
            await _db.SaveChangesAsync();
        }

        /// <summary>
        /// Зорчигчийн ID-аар захиалгын мэдээлэл олно.
        /// </summary>
        /// <param name="passengerId">Зорчигчийн ID</param>
        /// <returns>Захиалгын мэдээлэл эсвэл null</returns>
        public async Task<Reservation?> GetReservationByPassenger(int passengerId)
        {
            return await _db.Reservations.FirstOrDefaultAsync(r => r.PassengerId == passengerId);
        }

        /// <summary>
        /// Зорчигч болон нислэгийн ID-аар захиалгын мэдээлэл хайна.
        /// </summary>
        /// <param name="passengerId">Зорчигчийн ID</param>
        /// <param name="flightId">Нислэгийн ID</param>
        /// <returns>Захиалгын мэдээлэл эсвэл null</returns>
        public async Task<Reservation?> GetReservationByPassengerAndFlight(int passengerId, int flightId)
        {
            return await _db.Reservations
                      .FirstOrDefaultAsync(r => r.PassengerId == passengerId && r.FlightId == flightId);
        }
    }
}
