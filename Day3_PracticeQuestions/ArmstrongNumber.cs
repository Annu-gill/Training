using System;

// Check if a number equals the sum of its digits raised to power of number of digits
static class ArmstrongNumber
{
    public static void Execute()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());
        int temp = n, digits = 0, sum = 0;

        while (temp > 0)
        {
            digits++;
            temp /= 10;
        }

        temp = n;
        while (temp > 0)
        {
            int d = temp % 10;
            int power = 1;
            for (int i = 1; i <= digits; i++)
                power *= d;

            sum += power;
            temp /= 10;
        }

        Console.WriteLine(sum == n ? "Armstrong Number" : "Not Armstrong Number");
    }
}
