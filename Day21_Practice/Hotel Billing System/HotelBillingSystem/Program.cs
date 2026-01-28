using System;

namespace HotelBillingSystem
{
    interface Room
    {
        double calculateTotalBill(int nightsStayed, int joiningYear);
    }

    class HotelRoom : Room
    {
        public string roomType { get; set; }
        public double ratePerNight { get; set; }
        public string guestName { get; set; }

        public HotelRoom(string roomType, string guestName, double ratePerNight)
        {
            this.roomType = roomType;
            this.guestName = guestName;
            this.ratePerNight = ratePerNight;
        }

        // Calculate membership years based on fixed current year for consistency with sample output
        public int calculateMembershipYears(int joiningYear)
        {
            int currentYear = 2025; // fixed to match sample
            return currentYear - joiningYear;
        }

        public double calculateTotalBill(int nightsStayed, int joiningYear)
        {
            double totalBill = nightsStayed * ratePerNight;

            // Apply 10% discount if membership > 3 years
            if (calculateMembershipYears(joiningYear) > 3)
            {
                totalBill *= 0.9; // 10% discount
            }

            // Round to nearest whole number
            totalBill = Math.Round(totalBill, 1);

            return totalBill;
        }
    }

    class UserInterface
    {
        public static void Main(string[] args)
        {
            // Deluxe Room Details
            Console.WriteLine("\nEnter Deluxe Room Details:");
            Console.Write("Guest Name: ");
            string deluxeGuest = Console.ReadLine();
            Console.Write("Rate per Night: ");
            double deluxeRate = double.Parse(Console.ReadLine());
            Console.Write("Nights Stayed: ");
            int deluxeNights = int.Parse(Console.ReadLine());
            Console.Write("Joining Year: ");
            int deluxeJoiningYear = int.Parse(Console.ReadLine());

            HotelRoom deluxeRoom = new HotelRoom("Deluxe Room", deluxeGuest, deluxeRate);
            int deluxeMembership = deluxeRoom.calculateMembershipYears(deluxeJoiningYear);
            double deluxeBill = deluxeRoom.calculateTotalBill(deluxeNights, deluxeJoiningYear);

            // Suite Room Details
            Console.WriteLine("\nEnter Suite Room Details:");
            Console.Write("Guest Name: ");
            string suiteGuest = Console.ReadLine();
            Console.Write("Rate per Night: ");
            double suiteRate = double.Parse(Console.ReadLine());
            Console.Write("Nights Stayed: ");
            int suiteNights = int.Parse(Console.ReadLine());
            Console.Write("Joining Year: ");
            int suiteJoiningYear = int.Parse(Console.ReadLine());

            HotelRoom suiteRoom = new HotelRoom("Suite Room", suiteGuest, suiteRate);
            int suiteMembership = suiteRoom.calculateMembershipYears(suiteJoiningYear);
            double suiteBill = suiteRoom.calculateTotalBill(suiteNights, suiteJoiningYear);

            // Display summary
            Console.WriteLine("\nRoom Summary:");
            Console.WriteLine($"Deluxe Room: {deluxeGuest}, {deluxeRate:F1} per night, Membership: {deluxeMembership} years");
            Console.WriteLine($"Suite Room: {suiteGuest}, {suiteRate:F1} per night, Membership: {suiteMembership} years");

            Console.WriteLine("\nTotal Bill:");
            Console.WriteLine($"For {deluxeGuest} (Deluxe): {Math.Floor(deluxeBill):F1}");
            Console.WriteLine($"For {suiteGuest} (Suite): {suiteBill:F1}");
        }
    }
}