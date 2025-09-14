using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// Represents a reservation for a passenger on a specific flight.
    /// </summary>
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public required string SeatNumber { get; set; }
        public required Flight Flight { get; set; }
    }
}
