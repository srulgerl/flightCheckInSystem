using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    /// <summary>
    /// Data Transfer Object for Passenger with Seat Information
    /// </summary>
    public class PassengerWithSeatDto
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public string? SeatNumber { get; set; }
    }

}
