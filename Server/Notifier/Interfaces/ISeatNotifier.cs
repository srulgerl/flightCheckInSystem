using BusinessLogic.DTOs;

namespace Server.Notifier.Interfaces
{
    /// <summary>
    /// Notifies clients when a seat is assigned.
    /// </summary>
    public interface ISeatNotifier
    {
        /// <summary>
        /// Broadcasts a notification that a seat has been assigned.
        /// </summary>
        /// <param name="seat">The seat assignment details.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task BroadcastSeatAssignedAsync(SeatDto seat);
    }
}
