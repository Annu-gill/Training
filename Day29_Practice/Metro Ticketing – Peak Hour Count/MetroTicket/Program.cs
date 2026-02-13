using System;
using System.Collections.Generic;

class MetroTicketing
{
    public static void Main()
    {
        Queue<(TimeSpan entryTime, string ticketType)> q =
            new Queue<(TimeSpan, string)>();

        Console.Write("Enter number of passengers: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nPassenger {i + 1}:");

            Console.Write("Enter entry time (HH:mm): ");
            TimeSpan entryTime = TimeSpan.Parse(Console.ReadLine());

            Console.Write("Enter ticket type: ");
            string ticketType = Console.ReadLine();

            q.Enqueue((entryTime, ticketType));
        }

        int count = CountPeakRegularTickets(q);

        Console.WriteLine(
            $"\nRegular tickets sold during peak hours: {count}");
    }

    static int CountPeakRegularTickets(
        Queue<(TimeSpan entryTime, string ticketType)> q)
    {
        int count = 0;

        TimeSpan peakStart = new TimeSpan(8, 0, 0);  // 08:00
        TimeSpan peakEnd   = new TimeSpan(10, 0, 0); // 10:00

        while (q.Count > 0)
        {
            var passenger = q.Dequeue();

            // Check peak time range
            bool isPeakTime = passenger.entryTime >= peakStart &&
                              passenger.entryTime <= peakEnd;

            // Count only valid "Regular" tickets
            if (isPeakTime && passenger.ticketType == "Regular")
            {
                count++;
            }
        }

        return count;
    }
}
