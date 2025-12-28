using System;

// Calculate factorial and handle large numbers
static class FactorialLarge
{
    public static void Execute()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        System.Numerics.BigInteger fact = 1;
        for (int i = 1; i <= n; i++)
            fact *= i;

        Console.WriteLine("Factorial = " + fact);
    }
}
