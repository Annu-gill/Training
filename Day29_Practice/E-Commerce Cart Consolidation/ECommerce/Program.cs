using System;
using System.Collections.Generic;

class CartConsolidation
{
    public static void Main()
    {
        List<(string sku, int qty)> scans = new List<(string, int)>();

        Console.Write("Enter number of scans: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nScan {i + 1}:");

            Console.Write("Enter SKU: ");
            string sku = Console.ReadLine();

            Console.Write("Enter Quantity: ");
            int qty = int.Parse(Console.ReadLine());

            scans.Add((sku, qty));
        }

        Dictionary<string, int> skuQty = ConsolidateCart(scans);

        Console.WriteLine("\nConsolidated Cart:");
        foreach (var item in skuQty)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }

    static Dictionary<string, int> ConsolidateCart(List<(string sku, int qty)> scans)
    {
        Dictionary<string, int> result = new Dictionary<string, int>();

        foreach (var scan in scans)
        {
            // Ignore invalid quantities
            if (scan.qty <= 0)
                continue;

            if (result.ContainsKey(scan.sku))
                result[scan.sku] += scan.qty;
            else
                result[scan.sku] = scan.qty;
        }

        return result;
    }
}
