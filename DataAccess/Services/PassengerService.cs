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
        /// Retrieves all passengers
        /// </summary>
        /// <returns></returns>

        public async Task<IEnumerable<Passenger>> GetPassengers()
        {
            return await _passengerRepository.GetPassengersAsync();
        }

        /// <summary>
        /// Retrieves a passenger by passport number
        /// </summary>
        /// <param name="passportNumber"></param>
        /// <returns></returns>
        public async Task<Passenger?> GetPassengerByPassport(string passportNumber)
        {
            return await _passengerRepository.GetByPassportAsync(passportNumber);
        }

        /// <summary>
        /// Retrieves a passenger by passport number and flight ID
        /// </summary>
        /// <param name="passportNumber"></param>
        /// <param name="flightId"></param>
        /// <returns></returns>
        public async Task<Passenger?> GetPassengerByPassportAndFlight(string passportNumber, int flightId)
        {
            return _passengerRepository.GetPassengerByPassportAndFlight(passportNumber, flightId);
        }
    }
}
