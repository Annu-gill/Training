using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieTheaterBooking
{
    // ===================== MovieScreening Class =====================
    public class MovieScreening
    {
        public string MovieTitle { get; set; }
        public DateTime ShowTime { get; set; }
        public string ScreenNumber { get; set; }
        public int TotalSeats { get; set; }
        public int BookedSeats { get; set; }
        public double TicketPrice { get; set; }

        public int AvailableSeats => TotalSeats - BookedSeats;

        public double Revenue => BookedSeats * TicketPrice;
    }

    // ===================== Theater Manager =====================
    public class TheaterManager
    {
        private readonly List<MovieScreening> screenings = new List<MovieScreening>();

        // Add Screening
        public void AddScreening(string title, DateTime time, string screen, int seats, double price)
        {
            if (seats <= 0 || price <= 0)
                throw new ArgumentException("Seats and price must be greater than zero.");

            screenings.Add(new MovieScreening
            {
                MovieTitle = title,
                ShowTime = time,
                ScreenNumber = screen,
                TotalSeats = seats,
                TicketPrice = price,
                BookedSeats = 0
            });
        }

        // Book Tickets
        public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
        {
            MovieScreening screening = screenings.FirstOrDefault(s =>
                s.MovieTitle.Equals(movieTitle, StringComparison.OrdinalIgnoreCase)
                && s.ShowTime == showTime);

            if (screening == null || tickets <= 0)
                return false;

            if (screening.AvailableSeats < tickets)
                return false;

            screening.BookedSeats += tickets;
            return true;
        }

        // Group Screenings by Movie
        public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
        {
            return screenings
                .GroupBy(s => s.MovieTitle)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Calculate Total Revenue
        public double CalculateTotalRevenue()
        {
            return screenings.Sum(s => s.Revenue);
        }

        // Get Available Screenings
        public List<MovieScreening> GetAvailableScreenings(int minSeats)
        {
            return screenings
                .Where(s => s.AvailableSeats >= minSeats)
                .OrderBy(s => s.ShowTime)
                .ToList();
        }

        public List<MovieScreening> GetAllScreenings()
        {
            return screenings;
        }
    }

    // ===================== Program Class =====================
    class Program
    {
        public static void Main()
        {
            TheaterManager manager = new TheaterManager();

            while (true)
            {
                Console.WriteLine("\n===== Movie Theater Booking System =====");
                Console.WriteLine("1. Add Screening");
                Console.WriteLine("2. Book Tickets");
                Console.WriteLine("3. View Screenings by Movie");
                Console.WriteLine("4. Available Screenings (Group Booking)");
                Console.WriteLine("5. Total Revenue");
                Console.WriteLine("6. View All Screenings");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Movie Title: ");
                            string title = Console.ReadLine();

                            Console.Write("Show Time (yyyy-MM-dd HH:mm): ");
                            DateTime time = DateTime.Parse(Console.ReadLine());

                            Console.Write("Screen Number: ");
                            string screen = Console.ReadLine();

                            Console.Write("Total Seats: ");
                            int seats = int.Parse(Console.ReadLine());

                            Console.Write("Ticket Price: ");
                            double price = double.Parse(Console.ReadLine());

                            manager.AddScreening(title, time, screen, seats, price);
                            Console.WriteLine("Screening added successfully.");
                            break;

                        case 2:
                            Console.Write("Movie Title: ");
                            string bookTitle = Console.ReadLine();

                            Console.Write("Show Time (yyyy-MM-dd HH:mm): ");
                            DateTime bookTime = DateTime.Parse(Console.ReadLine());

                            Console.Write("Number of Tickets: ");
                            int tickets = int.Parse(Console.ReadLine());

                            bool success = manager.BookTickets(bookTitle, bookTime, tickets);
                            Console.WriteLine(success
                                ? "Tickets booked successfully."
                                : "Booking failed. Not enough seats or screening not found.");
                            break;

                        case 3:
                            var grouped = manager.GroupScreeningsByMovie();
                            foreach (var movie in grouped)
                            {
                                Console.WriteLine($"\nMovie: {movie.Key}");
                                foreach (var s in movie.Value)
                                {
                                    Console.WriteLine($"Time: {s.ShowTime}, Screen: {s.ScreenNumber}, Available: {s.AvailableSeats}");
                                }
                            }
                            break;

                        case 4:
                            Console.Write("Minimum seats required: ");
                            int minSeats = int.Parse(Console.ReadLine());

                            var available = manager.GetAvailableScreenings(minSeats);
                            foreach (var s in available)
                            {
                                Console.WriteLine($"{s.MovieTitle} | {s.ShowTime} | Screen {s.ScreenNumber} | Seats Left: {s.AvailableSeats}");
                            }
                            break;

                        case 5:
                            Console.WriteLine($"Total Revenue: ₹{manager.CalculateTotalRevenue():F2}");
                            break;

                        case 6:
                            foreach (var s in manager.GetAllScreenings())
                            {
                                Console.WriteLine($"{s.MovieTitle} | {s.ShowTime} | Screen {s.ScreenNumber} | Booked: {s.BookedSeats}/{s.TotalSeats}");
                            }
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
