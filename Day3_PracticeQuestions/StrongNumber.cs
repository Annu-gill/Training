using System;

// Check if sum of factorial of digits equals number
static class StrongNumber
{
    public static void Execute()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());
        int temp = n, sum = 0;

        while (temp > 0)
        {
            int d = temp % 10;
            int fact = 1;
            for (int i = 1; i <= d; i++)
                fact *= i;

            sum += fact;
            temp /= 10;
        }

        Console.WriteLine(sum == n ? "Strong Number" : "Not Strong Number");
    }
}
