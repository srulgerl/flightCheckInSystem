using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    /// <summary>
    /// Зорчигчийн мэдээлэлтэй ажиллах repository интерфэйс.
    /// Энэхүү интерфэйс нь зорчигчдын жагсаалт авах, пасспортын дугаараар хайх,
    /// пасспорт болон нислэгийн дугаараар зорчигчийн мэдээлэл авах зэрэг функцүүдийг тодорхойлдог.
    /// </summary>

    public interface IPassengerRepository
    {
        Task<IEnumerable<Passenger>> GetPassengersAsync();
        Task<Passenger?> GetByPassportAsync(string passportNumber);
        Passenger? GetPassengerByPassportAndFlight(string passportNumber, int flightId);

    }
}
