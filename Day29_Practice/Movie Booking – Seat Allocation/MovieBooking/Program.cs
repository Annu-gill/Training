using System;
using System.Collections.Generic;

class MovieSeatAllocation
{
    public static void Main()
    {
        // Read total number of seats
        Console.Write("Enter total number of seats (N): ");
        int n = int.Parse(Console.ReadLine());

        // Read already booked seats
        Console.Write("Enter number of already booked seats: ");
        int b = int.Parse(Console.ReadLine());

        List<int> alreadyBooked = new List<int>();
        Console.WriteLine("Enter already booked seat numbers:");

        for (int i = 0; i < b; i++)
        {
            alreadyBooked.Add(int.Parse(Console.ReadLine()));
        }

        // Read number of booking requests
        Console.Write("\nEnter number of seat requests: ");
        int requestCount = int.Parse(Console.ReadLine());

        List<int> allocatedSeats =
            AllocateSeats(n, alreadyBooked, requestCount);

        // Display result
        Console.WriteLine("\nAllocated Seats:");
        foreach (int seat in allocatedSeats)
        {
            Console.Write(seat + " ");
        }
    }

    static List<int> AllocateSeats(
        int n, List<int> alreadyBooked, int requestCount)
    {
        // Initialize all seats as available
        SortedSet<int> availableSeats = new SortedSet<int>();

        for (int i = 1; i <= n; i++)
        {
            availableSeats.Add(i);
        }

        // Remove already booked seats
        foreach (int seat in alreadyBooked)
        {
            availableSeats.Remove(seat);
        }

        List<int> allocated = new List<int>();

        for (int i = 0; i < requestCount; i++)
        {
            if (availableSeats.Count > 0)
            {
                int lowestSeat = availableSeats.Min;
                allocated.Add(lowestSeat);
                availableSeats.Remove(lowestSeat);
            }
            else
            {
                allocated.Add(-1); // No seats available
            }
        }

        return allocated;
    }
}
