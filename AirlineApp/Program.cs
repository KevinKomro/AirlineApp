using System;
using System.Collections.Generic;

namespace AirlineApp
{

    public enum SeatPosition
    {
        Aisle,
        Middle,
        Window
    }
    class Program
    {

        public struct Seat
        {
            public string SeatNumber { get; set; }
            public SeatPosition SeatPosition { get; set; }
            public bool isAvailable { get; set; }
        }

        public class Plane
        {
            public string TailNumber { get; set; }
            public string FlightNumber { get; set; }
            public List<Seat> Seats { get; set; }


            public IEnumerable<Seat> getAvailableSeats()
            {
                var availableSeats = new List<Seat>();
                foreach (Seat seat in Seats)
                {
                    if (seat.isAvailable)
                    {
                        availableSeats.Add(seat);
                    }
                }
                return (IEnumerable<Seat>)availableSeats;
            }
        }

        static void Main(string[] args)
        {
            Plane plane = new Plane();

            plane.Seats = new List<Seat>();

            for (int i = 1; i <= 10; i++)
            {
                plane.Seats.Add(new Seat { SeatNumber = $"{i}a", SeatPosition = (SeatPosition)2, isAvailable = true });
                plane.Seats.Add(new Seat { SeatNumber = $"{i}b", SeatPosition = (SeatPosition)1, isAvailable = true });
                plane.Seats.Add(new Seat { SeatNumber = $"{i}c", SeatPosition = (SeatPosition)0, isAvailable = false });
                plane.Seats.Add(new Seat { SeatNumber = $"{i}d", SeatPosition = (SeatPosition)0, isAvailable = false });
                plane.Seats.Add(new Seat { SeatNumber = $"{i}e", SeatPosition = (SeatPosition)1, isAvailable = true });
                plane.Seats.Add(new Seat { SeatNumber = $"{i}f", SeatPosition = (SeatPosition)2, isAvailable = true });
            };

            Console.WriteLine("List of Available seats:");

            foreach (Seat seat in plane.getAvailableSeats())
            {
                Console.WriteLine($"Seat: {seat.SeatNumber}" + $" {seat.SeatPosition}");
            }

        }
    }
}
