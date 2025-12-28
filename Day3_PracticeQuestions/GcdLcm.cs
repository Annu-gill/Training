using System;

// Find GCD and LCM of two numbers
static class GcdLcm
{
    public static void Execute()
    {
        Console.Write("Enter first number: ");
        int a = int.Parse(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = int.Parse(Console.ReadLine());

        int x = a, y = b;
        while (y != 0)
        {
            int r = x % y;
            x = y;
            y = r;
        }

        int gcd = x;
        int lcm = (a * b) / gcd;

        Console.WriteLine("GCD = " + gcd);
        Console.WriteLine("LCM = " + lcm);
    }
}
