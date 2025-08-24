using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;

namespace DataAccess.Repositories
{
    public interface IPassengerRepository
    {
        Task<IEnumerable<Passenger>> GetPassengersAsync();
        Task<Passenger?> GetByPassportAsync(string passportNumber);
        Passenger? GetPassengerByPassportAndFlight(string passportNumber, int flightId);

    }
}
