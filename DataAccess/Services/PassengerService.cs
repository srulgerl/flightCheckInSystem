using DataAccess.Models;
using DataAccess.Repositories;

namespace BusinessLogic.Services
{
    public class PassengerService
    {
        private readonly IPassengerRepository _passengerRepository;

        public PassengerService(IPassengerRepository passengerRepository)
        {
            _passengerRepository = passengerRepository;
        }

        public async Task<IEnumerable<Passenger>> GetPassengers()
        {
            return await _passengerRepository.GetPassengersAsync();
        }

        public async Task<Passenger?> GetPassengerByPassport(string passportNumber)
        {
            return await _passengerRepository.GetByPassportAsync(passportNumber);
        }

        public async Task<Passenger?> GetPassengerByPassportAndFlight(string passportNumber, int flightId)
        {
            return _passengerRepository.GetPassengerByPassportAndFlight(passportNumber, flightId);
        }

    }
}
