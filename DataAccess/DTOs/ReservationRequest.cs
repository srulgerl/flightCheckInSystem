using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class ReservationRequest
    {
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public string SeatNumber { get; set; }
    }

}
