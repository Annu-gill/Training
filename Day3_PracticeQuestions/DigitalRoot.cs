using System;

// Sum digits until single digit (Digital Root)
static class DigitalRoot
{
    public static void Execute()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        while (n >= 10)
        {
            int sum = 0;
            while (n > 0)
            {
                sum += n % 10;
                n /= 10;
            }
            n = sum;
        }

        Console.WriteLine("Digital Root = " + n);
    }
}
