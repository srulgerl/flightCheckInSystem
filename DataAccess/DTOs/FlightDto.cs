using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    /// <summary>
    /// Нислэгийн Data Transfer Object-ийг төлөөлдөг.
    /// Represents a Data Transfer Object for a Flight.
    /// </summary>
    public class FlightDto
    {
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
    }
}
