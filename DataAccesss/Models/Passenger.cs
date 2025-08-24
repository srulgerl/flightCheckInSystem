using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public int FlightId { get; set; }
        public Flight Flight { get; set; }

        public ICollection<Reservation> Reservations { get; set; }

    }
}
