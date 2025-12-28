using System;

// Display the first N terms of Fibonacci series
static class FibonacciSeries
{
    public static void Execute()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());

        int a = 0, b = 1;
        for (int i = 1; i <= n; i++)
        {
            Console.Write(a + " ");
            int c = a + b;
            a = b;
            b = c;
        }
    }
}
