using DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Models;


namespace DataAccess.Context {
    public static class DbInitializer
    {
        /// <summary>
        /// Seeds initial data into the database if no data exists.
        /// </summary>
        /// <param name="db"></param>
        public static void Seed(ApplicationDBContext db)
        {
            if (!db.Flights.Any())
            {
                db.Flights.AddRange(
                    new Flight
                    {
                        FlightNumber = "FL123",
                        DepartureAirport = "ULN",
                        ArrivalAirport = "ICN",
                        DepartureTime = DateTime.Now.AddHours(2),
                        ArrivalTime = DateTime.Now.AddHours(5),
                        Status = FlightStatus.CheckingIn
                    },
                    new Flight
                    {
                        FlightNumber = "FL456",
                        DepartureAirport = "ULN",
                        ArrivalAirport = "NRT",
                        DepartureTime = DateTime.Now.AddHours(4),
                        ArrivalTime = DateTime.Now.AddHours(8),
                        Status = FlightStatus.CheckingIn
                    },
                    new Flight
                    {
                        FlightNumber = "FL789",
                        DepartureAirport = "ULN",
                        ArrivalAirport = "PEK",
                        DepartureTime = DateTime.Now.AddHours(6),
                        ArrivalTime = DateTime.Now.AddHours(9),
                        Status = FlightStatus.CheckingIn
                    },
                    new Flight
                    {
                        FlightNumber = "FL321",
                        DepartureAirport = "ULN",
                        ArrivalAirport = "LHR",
                        DepartureTime = DateTime.Now.AddHours(10),
                        ArrivalTime = DateTime.Now.AddHours(18),
                        Status = FlightStatus.CheckingIn
                    }
                );
                db.SaveChanges(); // Flight-уудыг эхлээд хадгална
            }

            if (!db.Passengers.Any())
            {
                var fl123 = db.Flights.First(f => f.FlightNumber == "FL123");
                var fl456 = db.Flights.First(f => f.FlightNumber == "FL456");
                var fl789 = db.Flights.First(f => f.FlightNumber == "FL789");
                var fl321 = db.Flights.First(f => f.FlightNumber == "FL321");

                db.Passengers.AddRange(
                    // FL123 зорчигчид
                    new Passenger { Name = "Бат", PassportNumber = "P123456", FlightId = fl123.FlightId },
                    new Passenger { Name = "Оюунаа", PassportNumber = "P123457", FlightId = fl123.FlightId },

                    // FL456 зорчигчид
                    new Passenger { Name = "Сараа", PassportNumber = "P654321", FlightId = fl456.FlightId },
                    new Passenger { Name = "Дөлгөөн", PassportNumber = "P654322", FlightId = fl456.FlightId },

                    // FL789 зорчигчид
                    new Passenger { Name = "John Smith", PassportNumber = "P111222", FlightId = fl789.FlightId },
                    new Passenger { Name = "Michael Chen", PassportNumber = "P111223", FlightId = fl789.FlightId },

                    // FL321 зорчигчид
                    new Passenger { Name = "Jane Doe", PassportNumber = "P333444", FlightId = fl321.FlightId },
                    new Passenger { Name = "Emma Watson", PassportNumber = "P333445", FlightId = fl321.FlightId }
                );
                db.SaveChanges();
            }
        }
    }
}
