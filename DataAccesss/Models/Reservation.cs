using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// Захиалгийн модэл бүхий класс
    /// </summary>
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public string SeatNumber { get; set; }

        public Flight Flight { get; set; }
        public Passenger Passenger { get; set; }
    }
}
