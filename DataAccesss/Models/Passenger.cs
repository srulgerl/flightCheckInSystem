using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Models
{
    /// <summary>
    /// Зорчигчийн модэл бүхий класс
    /// </summary>
    public class Passenger
    {
        public int PassengerId { get; set; }
        public string Name { get; set; }
        public string PassportNumber { get; set; }
        public int FlightId { get; set; }
        
        //public ICollection<Reservation> Reservations { get; set; }

    }
}
