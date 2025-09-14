using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataAccess.Models;
using DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using BusinessLogic.DTOs;

public class ReservationService
{
    private readonly IReservationRepository _reservationRepository;

    public ReservationService(IReservationRepository reservationRepository)
    {
        _reservationRepository = reservationRepository;
    }

    /// <summary>
    /// Зорчигчид суудал оноох (өмнө суудалтай бол солино). Реал-тайм дуудлага ХИЙХГҮЙ.
    /// </summary>
    public async Task<ReservationResult> CreateOrUpdateReservationAsync(
        Reservation reservation,
        CancellationToken ct = default)
    {
        // check if seat is taken by another passenger
        var taken = await _reservationRepository
            .GetReservationBySeatAsync(reservation.FlightId, reservation.SeatNumber, ct);

        if (taken is not null && taken.PassengerId != reservation.PassengerId)
        {
            return new ReservationResult(false,
                $"❌ Seat {reservation.SeatNumber} is already taken!",
                reservation.FlightId, reservation.PassengerId, reservation.SeatNumber);
        }

        // 2) Энэ зорчигчийн уг нислэг дээрх одоогийн захиалга
        var existing = await _reservationRepository
            .GetReservationByPassengerAndFlight(reservation.PassengerId, reservation.FlightId, ct);

        try
        {
            if (existing is null)
            {
                await _reservationRepository.AddReservationAsync(reservation, ct);
            }
            else
            {
                existing.SeatNumber = reservation.SeatNumber;
                await _reservationRepository.UpdateReservationAsync(existing, ct);
            }

            return new ReservationResult(true,
                $"✅ Seat {reservation.SeatNumber} reserved successfully",
                reservation.FlightId, reservation.PassengerId, reservation.SeatNumber);
        }
        catch (DbUpdateException ex)
        {
            if (ex.InnerException?.Message.Contains("UNIQUE", StringComparison.OrdinalIgnoreCase) == true)
            {
                return new ReservationResult(false,
                    $"❌ Seat {reservation.SeatNumber} is already taken!",
                    reservation.FlightId, reservation.PassengerId, reservation.SeatNumber);
            }

            return new ReservationResult(false,
                "❌ Database error: " + (ex.InnerException?.Message ?? ex.Message),
                reservation.FlightId, reservation.PassengerId, reservation.SeatNumber);
        }
    }

    /// Gets all reservations for a specific flight.
    /// </summary>
    /// <param name="flightId">The ID of the flight.</param>
    /// <returns>A collection of reservations for the specified flight.</returns>
    /// </summary>
    /// <param name="flightId"></param>
    /// <returns></returns>
    public Task<IEnumerable<Reservation>> GetReservationsByFlight(int flightId)
        => _reservationRepository.GetReservationsByFlight(flightId);

    /// <summary>
    /// Gets a reservation for a specific passenger on a specific flight.
    /// </summary>
    /// <param name="passengerId">The ID of the passenger.</param>
    /// <param name="flightId">The ID of the flight.</param>
    /// <returns>The reservation if found; otherwise, null.</returns>
    public Task<Reservation?> GetReservationByPassengerAndFlight(int passengerId, int flightId)
        => _reservationRepository.GetReservationByPassengerAndFlight(passengerId, flightId);

}
