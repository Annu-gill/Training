using System;

// Check if a number is prime using for loop and break
static class PrimeNumber
{
    public static void Execute()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());
        bool prime = true;

        if (n <= 1) prime = false;

        for (int i = 2; i <= n / 2; i++)
        {
            if (n % i == 0)
            {
                prime = false;
                break;
            }
        }

        Console.WriteLine(prime ? "Prime" : "Not Prime");
    }
}
