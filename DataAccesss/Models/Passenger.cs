using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// Represents a passenger with identification and flight information.
    /// </summary>
    public class Passenger
    {
        public int PassengerId { get; set; }
        public required string Name { get; set; }
        public required string PassportNumber { get; set; }
        public int FlightId { get; set; }
    }
}
