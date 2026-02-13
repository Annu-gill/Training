using System;
using System.Collections.Generic;

class AttendanceFirstUnique
{
    public static void Main()
    {
        Console.Write("Enter number of scans: ");
        int n = int.Parse(Console.ReadLine());

        List<int> scans = new List<int>();

        Console.WriteLine("Enter employee IDs:");

        for (int i = 0; i < n; i++)
        {
            scans.Add(int.Parse(Console.ReadLine()));
        }

        List<int> firstTime = GetFirstUnique(scans);

        Console.WriteLine("\nFirst-time entries:");
        foreach (int id in firstTime)
        {
            Console.Write(id + " ");
        }
    }

    static List<int> GetFirstUnique(List<int> scans)
    {
        HashSet<int> seen = new HashSet<int>();
        List<int> result = new List<int>();

        foreach (int id in scans)
        {
            // Add returns true only if element is not already present
            if (seen.Add(id))
            {
                result.Add(id);
            }
        }

        return result;
    }
}
