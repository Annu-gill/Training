using System;
using System.Collections.Generic;

class LogAnalyzer
{
    public static void Main()
    {
        List<string> codes = new List<string>();

        Console.Write("Enter number of error codes: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter error codes:");

        for (int i = 0; i < n; i++)
        {
            codes.Add(Console.ReadLine());
        }

        string result = FindMostFrequentCode(codes);

        Console.WriteLine("\nMost Frequent Error Code:");
        Console.WriteLine(result);
    }

    static string FindMostFrequentCode(List<string> codes)
    {
        Dictionary<string, int> freq = new Dictionary<string, int>();

        // Count frequency
        foreach (string code in codes)
        {
            if (freq.ContainsKey(code))
                freq[code]++;
            else
                freq[code] = 1;
        }

        string result = "";
        int maxCount = 0;

        // Find highest frequency with lexicographic tie-break
        foreach (var item in freq)
        {
            if (item.Value > maxCount ||
               (item.Value == maxCount &&
                string.Compare(item.Key, result) < 0))
            {
                maxCount = item.Value;
                result = item.Key;
            }
        }

        return result;
    }
}
