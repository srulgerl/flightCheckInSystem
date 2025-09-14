namespace Server.Notifier.Interfaces
{
    /// <summary>
    /// Provides functionality to broadcast flight status updates.
    /// </summary>
    public interface IFlightNotifier
    {
        /// <summary>
        /// Broadcasts the status update for a specific flight.
        /// </summary>
        /// <param name="flightId">The unique identifier of the flight.</param>
        /// <param name="status">The status message to broadcast.</param>
        /// <returns>A task representing the asynchronous operation.</returns>
        Task BroadcastStatusAsync(int flightId, string status);
    }
}

