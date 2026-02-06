using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRentalAgency
{
    // ===================== RentalCar Class =====================
    public class RentalCar
    {
        public string LicensePlate { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string CarType { get; set; }   // Sedan / SUV / Van
        public bool IsAvailable { get; set; }
        public double DailyRate { get; set; }
    }

    // ===================== Rental Class =====================
    public class Rental
    {
        public int RentalId { get; set; }
        public string LicensePlate { get; set; }
        public string CustomerName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double TotalCost { get; set; }
    }

    // ===================== Rental Manager =====================
    public class RentalManager
    {
        private readonly List<RentalCar> cars = new List<RentalCar>();
        private readonly List<Rental> rentals = new List<Rental>();
        private int nextRentalId = 1;

        // Add Car
        public void AddCar(string license, string make, string model, string type, double rate)
        {
            if (rate <= 0)
                throw new ArgumentException("Daily rate must be greater than zero.");

            cars.Add(new RentalCar
            {
                LicensePlate = license,
                Make = make,
                Model = model,
                CarType = type,
                DailyRate = rate,
                IsAvailable = true
            });
        }

        // Rent Car
        public bool RentCar(string license, string customer, DateTime start, int days)
        {
            RentalCar car = cars.FirstOrDefault(c =>
                c.LicensePlate.Equals(license, StringComparison.OrdinalIgnoreCase));

            if (car == null || !car.IsAvailable || days <= 0)
                return false;

            DateTime end = start.AddDays(days);
            double cost = days * car.DailyRate;

            rentals.Add(new Rental
            {
                RentalId = nextRentalId++,
                LicensePlate = car.LicensePlate,
                CustomerName = customer,
                StartDate = start,
                EndDate = end,
                TotalCost = cost
            });

            car.IsAvailable = false;
            return true;
        }

        // Group Cars by Type (Available Only)
        public Dictionary<string, List<RentalCar>> GroupCarsByType()
        {
            return cars
                .Where(c => c.IsAvailable)
                .GroupBy(c => c.CarType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get Active Rentals
        public List<Rental> GetActiveRentals()
        {
            DateTime today = DateTime.Now;
            return rentals
                .Where(r => r.StartDate <= today && r.EndDate >= today)
                .ToList();
        }

        // Calculate Total Revenue
        public double CalculateTotalRentalRevenue()
        {
            return rentals.Sum(r => r.TotalCost);
        }

        public List<RentalCar> GetAllCars() => cars;
        public List<Rental> GetAllRentals() => rentals;
    }

    // ===================== Program Class =====================
    class Program
    {
        public static void Main()
        {
            RentalManager manager = new RentalManager();

            while (true)
            {
                Console.WriteLine("\n===== Car Rental Agency =====");
                Console.WriteLine("1. Add Car");
                Console.WriteLine("2. Rent Car");
                Console.WriteLine("3. Available Cars by Type");
                Console.WriteLine("4. Active Rentals");
                Console.WriteLine("5. Total Revenue");
                Console.WriteLine("6. View All Cars");
                Console.WriteLine("0. Exit");
                Console.Write("Select option: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("License Plate: ");
                            string license = Console.ReadLine();

                            Console.Write("Make: ");
                            string make = Console.ReadLine();

                            Console.Write("Model: ");
                            string model = Console.ReadLine();

                            Console.Write("Car Type (Sedan/SUV/Van): ");
                            string type = Console.ReadLine();

                            Console.Write("Daily Rate: ");
                            double rate = double.Parse(Console.ReadLine());

                            manager.AddCar(license, make, model, type, rate);
                            Console.WriteLine("Car added successfully.");
                            break;

                        case 2:
                            Console.Write("License Plate: ");
                            string rentLicense = Console.ReadLine();

                            Console.Write("Customer Name: ");
                            string customer = Console.ReadLine();

                            Console.Write("Start Date (yyyy-MM-dd): ");
                            DateTime start = DateTime.Parse(Console.ReadLine());

                            Console.Write("Number of Days: ");
                            int days = int.Parse(Console.ReadLine());

                            bool rented = manager.RentCar(rentLicense, customer, start, days);
                            Console.WriteLine(rented
                                ? "Car rented successfully."
                                : "Rental failed. Car not available.");
                            break;

                        case 3:
                            var grouped = manager.GroupCarsByType();
                            foreach (var group in grouped)
                            {
                                Console.WriteLine($"\n{group.Key} Cars:");
                                foreach (var car in group.Value)
                                {
                                    Console.WriteLine($"{car.LicensePlate} - {car.Make} {car.Model} - ₹{car.DailyRate}/day");
                                }
                            }
                            break;

                        case 4:
                            var active = manager.GetActiveRentals();
                            foreach (var r in active)
                            {
                                Console.WriteLine($"Rental ID: {r.RentalId}, Car: {r.LicensePlate}, Customer: {r.CustomerName}");
                            }
                            break;

                        case 5:
                            Console.WriteLine($"Total Revenue: ₹{manager.CalculateTotalRentalRevenue():F2}");
                            break;

                        case 6:
                            foreach (var car in manager.GetAllCars())
                            {
                                Console.WriteLine($"{car.LicensePlate} | {car.Make} {car.Model} | {car.CarType} | Available: {car.IsAvailable}");
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
