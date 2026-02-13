using System;
using System.Collections.Generic;

class BankStatementSpend
{
    public static void Main()
    {
        List<(string category, decimal amount)> txns =
            new List<(string, decimal)>();

        Console.Write("Enter number of transactions: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nTransaction {i + 1}:");

            Console.Write("Enter category: ");
            string category = Console.ReadLine();

            Console.Write("Enter amount: ");
            decimal amount = decimal.Parse(Console.ReadLine());

            txns.Add((category, amount));
        }

        Dictionary<string, decimal> spendByCategory =
            CalculateSpendByCategory(txns);

        Console.WriteLine("\nSpend By Category:");
        foreach (var item in spendByCategory)
        {
            Console.WriteLine($"{item.Key} : {item.Value}");
        }
    }

    static Dictionary<string, decimal> CalculateSpendByCategory(
        List<(string category, decimal amount)> txns)
    {
        Dictionary<string, decimal> result =
            new Dictionary<string, decimal>();

        foreach (var txn in txns)
        {
            // Consider only spending (negative amounts)
            if (txn.amount < 0)
            {
                decimal spend = Math.Abs(txn.amount);

                if (result.ContainsKey(txn.category))
                    result[txn.category] += spend;
                else
                    result[txn.category] = spend;
            }
        }

        return result;
    }
}
