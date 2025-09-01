using DataAccess.Context;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Зорчигчдын мэдээлэлтэй ажиллах repository-ийн хэрэгжилт.
    /// Энэ ангид зорчигчдын жагсаалт авах, пасспортын дугаараар болон
    /// пасспорт + нислэгийн мэдээллээр зорчигч хайх функцүүдийг хэрэгжүүлдэг.
    /// </summary>
    public class PassengerRepository : IPassengerRepository
    {
        private readonly ApplicationDBContext _db;

        /// <summary>
        /// PassengerRepository-ийн шинэ экземплярыг үүсгэх конструктор.
        /// </summary>
        /// <param name="db">Өгөгдлийн сантай холбогдох контекст</param>
        public PassengerRepository(ApplicationDBContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Бүх зорчигчдын жагсаалтыг өгөгдлийн сангаас авч ирнэ.
        /// </summary>
        /// <returns>Зорчигчдын жагсаалт</returns>
        public async Task<IEnumerable<Passenger>> GetPassengersAsync()
        {
            return await _db.Passengers.ToListAsync();
        }

        /// <summary>
        /// Пасспортын дугаараар зорчигчийг өгөгдлийн сангаас хайж олно.
        /// </summary>
        /// <param name="passportNumber">Пасспортын дугаар</param>
        /// <returns>Хэрэв олдвол зорчигчийн мэдээлэл, эсвэл null</returns>
        public async Task<Passenger?> GetByPassportAsync(string passportNumber)
        {
            return await _db.Passengers
                .FirstOrDefaultAsync(p => p.PassportNumber == passportNumber);
        }

        /// <summary>
        /// Пасспортын дугаар болон нислэгийн дугаараар зорчигчийг хайна.
        /// </summary>
        /// <param name="passportNumber">Пасспортын дугаар</param>
        /// <param name="flightId">Нислэгийн ID</param>
        /// <returns>Хэрэв олдвол зорчигчийн мэдээлэл, эсвэл null</returns>
        public Passenger? GetPassengerByPassportAndFlight(string passportNumber, int flightId)
        {
            return _db.Passengers
                      .FirstOrDefault(p => p.PassportNumber == passportNumber && p.FlightId == flightId);
        }
    }
}
