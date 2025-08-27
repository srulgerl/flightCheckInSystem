using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    public class FlightDto
    {
        public required string FlightNumber { get; set; }
        public required string Status { get; set; }
        public int FlightId { get; set; }
        public string FlightName { get; set; }
        public DateTime DepartureTime { get; set; }
        public DateTime ArrivalTime { get; set; }
        public string DepartureAirport { get; set; }
        public string ArrivalAirport { get; set; }

    }
}
