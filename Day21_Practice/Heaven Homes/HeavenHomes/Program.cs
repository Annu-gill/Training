using System;
using System.Collections.Generic;

class Apartment
{
    private Dictionary<string, double> apartmentDetailsMap = new Dictionary<string, double>();

    // Add apartment details
    public void addApartmentDetails(string apartmentNumber, double rent)
    {
        apartmentDetailsMap[apartmentNumber] = rent;
    }

    // Find total rent within the given range
    public double findTotalRentOfApartmentsInTheGivenRange(double minimumRent, double maximumRent)
    {
        double totalRent = 0;

        foreach (var apartment in apartmentDetailsMap)
        {
            if (apartment.Value >= minimumRent && apartment.Value <= maximumRent)
            {
                totalRent += apartment.Value;
            }
        }

        return totalRent;
    }
}

class UserInterface
{
    public static void Main()
    {
        Apartment apartment = new Apartment();

        Console.WriteLine("Enter number of details to be added");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the details (Apartment number: Rent)");
        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(':');

            string apartmentNumber = parts[0];
            double rent = double.Parse(parts[1]);

            apartment.addApartmentDetails(apartmentNumber, rent);
        }

        Console.WriteLine("Enter the range to filter the details");
        double minRent = double.Parse(Console.ReadLine());
        double maxRent = double.Parse(Console.ReadLine());

        double totalRent = apartment.findTotalRentOfApartmentsInTheGivenRange(minRent, maxRent);

        if (totalRent > 0)
        {
            Console.WriteLine(
                $"Total Rent in the range {minRent:F1} to {maxRent:F1} USD:{totalRent:F1}"
            );
        }
        else
        {
            Console.WriteLine("No apartments found in this range");
        }
    }
}