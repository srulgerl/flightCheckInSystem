using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.DTOs
{
    /// <summary>
    /// Request model for creating a reservation
    /// </summary>
    public class CreateReservationRequest
    {
        /// <summary>
        /// Flgiht ID
        /// </summary>
        public int FlightId { get; set; }
        /// <summary>
        ///  Passenger ID
        /// </summary>
        public int PassengerId { get; set; }
        /// <summary>
        /// Seat Number
        /// </summary>
        public string SeatNumber { get; set; }
    }
}
