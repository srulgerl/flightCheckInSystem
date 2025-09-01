using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    /// <summary>
    /// Represents a passenger with associated details such as ID, name, passport number, and optional seat number.
    /// Зорчигчийн ID, нэр, пасспортын дугаар болон сонголттой суудлын дугаарыг агуулсан зорчигчийг төлөөлдөг.
    /// </summary>
    public class PassengerWithSeatDto
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public string? SeatNumber { get; set; }
    }

}
