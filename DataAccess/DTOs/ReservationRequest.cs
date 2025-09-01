using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    /// <summary>
    /// Represents a request to reserve a seat on a flight. Contains properties for the flight ID, passenger ID, and
    /// seat number.
    /// Захиалгийн хүсэлтийг төлөөлдөг. Үүнд нислэгийн ID, зорчигчийн ID, суудлын дугаар зэрэг шинж чанарууд орно.
    /// </summary>
    public class ReservationRequest
    {
        public int FlightId { get; set; }
        public int PassengerId { get; set; }
        public string SeatNumber { get; set; }
    }

}
