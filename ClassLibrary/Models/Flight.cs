using System;
using System.Collections.Generic;

namespace DataAccess.Models
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public string Destination { get; set; }
        public DateTime DepartureTime { get; set; }
        public FlightStatus Status { get; set; }
        public string AircraftType { get; set; }
        public int TotalSeats { get; set; }
    }

    public enum FlightStatus
    {
        CheckingIn,
        Boarding,
        Departed,
        Delayed,
        Cancelled
    }
}
