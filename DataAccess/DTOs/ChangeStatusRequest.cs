using DataAccess.Models;

namespace BusinessLogic.DTOs
{
    /// <summary>
    /// Нислэгийн статус өөрчлөх хүсэлт
    /// </summary>
    public class ChangeStatusRequest
    {
        /// <summary>
        /// Нислэгийн ID
        /// </summary>
        public int FlightId { get; set; }
        /// <summary>
        /// Шинэ статус
        /// </summary>
        public string Status { get; set; } = string.Empty;
    }

}
