using System;
using System.Collections.Generic;

class InventoryDuplicateSerials
{
    public static void Main()
    {
        List<string> serials = new List<string>();

        Console.Write("Enter number of serial numbers: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter serial numbers:");

        for (int i = 0; i < n; i++)
        {
            serials.Add(Console.ReadLine());
        }

        List<string> duplicates = FindDuplicates(serials);

        Console.WriteLine("\nDuplicate Serials:");
        foreach (string s in duplicates)
        {
            Console.Write(s + " ");
        }
    }

    static List<string> FindDuplicates(List<string> serials)
    {
        HashSet<string> seen = new HashSet<string>();
        HashSet<string> added = new HashSet<string>(); // to avoid repeat duplicates
        List<string> duplicates = new List<string>();

        foreach (string serial in serials)
        {
            // If already seen, it's a duplicate
            if (!seen.Add(serial))
            {
                // Add duplicate only once and preserve order
                if (!added.Contains(serial))
                {
                    duplicates.Add(serial);
                    added.Add(serial);
                }
            }
        }

        return duplicates;
    }
}
