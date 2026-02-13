using System;
using System.Collections.Generic;

class MergeTicketStreams
{
    public static void Main()
    {
        // Read first sorted list
        Console.Write("Enter size of first list: ");
        int n = int.Parse(Console.ReadLine());

        List<int> a = new List<int>();
        Console.WriteLine("Enter elements of first list (sorted):");
        for (int i = 0; i < n; i++)
        {
            a.Add(int.Parse(Console.ReadLine()));
        }

        // Read second sorted list
        Console.Write("\nEnter size of second list: ");
        int m = int.Parse(Console.ReadLine());

        List<int> b = new List<int>();
        Console.WriteLine("Enter elements of second list (sorted):");
        for (int i = 0; i < m; i++)
        {
            b.Add(int.Parse(Console.ReadLine()));
        }

        List<int> merged = MergeSortedLists(a, b);

        // Display result
        Console.WriteLine("\nMerged Ticket Stream:");
        foreach (int x in merged)
        {
            Console.Write(x + " ");
        }
    }

    static List<int> MergeSortedLists(List<int> a, List<int> b)
    {
        List<int> result = new List<int>();

        int i = 0, j = 0;

        // Two-pointer merge
        while (i < a.Count && j < b.Count)
        {
            if (a[i] <= b[j])
            {
                result.Add(a[i]);
                i++;
            }
            else
            {
                result.Add(b[j]);
                j++;
            }
        }

        // Add remaining elements
        while (i < a.Count)
        {
            result.Add(a[i]);
            i++;
        }

        while (j < b.Count)
        {
            result.Add(b[j]);
            j++;
        }

        return result;
    }
}
