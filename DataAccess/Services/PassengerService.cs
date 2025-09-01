using DataAccess.Models;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    /// <summary>
    /// Зорчигчийн үйл ажиллагааг удирдах үйлчилгээ.
    /// </summary>
    public class PassengerService
    {
        private readonly IPassengerRepository _passengerRepository;

        /// <summary>
        /// Зорчигчийн үйлчилгээний анхны тохиргоо.
        /// </summary>
        /// <param name="passengerRepository">Зорчигчийн өгөгдлийн сангийн репозиторийг оруулна.</param>
        public PassengerService(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        /// <summary>
        /// Зорчигчдын жагсаалтыг асинхрон байдлаар авах.
        /// </summary>
        /// <returns>Зорчигчийн объектуудын enumerable цуглуулга.</returns>
        public async Task<IEnumerable<Passenger>> GetPassengers()
        {
            return await _passengerRepository.GetPassengersAsync();
        }

        /// <summary>
        /// Паспортын дугаараар зорчигчийн мэдээллийг авах.
        /// </summary>
        /// <param name="passportNumber">Зорчигчийн өвөрмөц паспортын дугаар.</param>
        /// <returns>Хэрэв олдвол зорчигчийн объект, эс бөгөөс null буцаана.</returns>
        public async Task<Passenger?> GetPassengerByPassport(string passportNumber)
        {
            return await _passengerRepository.GetByPassportAsync(passportNumber);
        }

        /// <summary>
        /// Паспортын дугаар болон нислэгийн дугаараар зорчигчийн мэдээллийг авах.
        /// </summary>
        /// <param name="passportNumber">Зорчигчийн паспортын дугаар.</param>
        /// <param name="flightId">Нислэгийн дугаар.</param>
        /// <returns>Хэрэв олдвол зорчигчийн объект, эс бөгөөс null буцаана.</returns>
        public async Task<Passenger?> GetPassengerByPassportAndFlight(string passportNumber, int flightId)
        {
            return _passengerRepository.GetPassengerByPassportAndFlight(passportNumber, flightId);
        }
    }
}
