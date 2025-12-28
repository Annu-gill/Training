using System;

// Convert binary string to decimal without built-in functions
static class BinaryToDecimal
{
    public static void Execute()
    {
        Console.Write("Enter binary number: ");
        string bin = Console.ReadLine();

        int dec = 0, power = 1;
        for (int i = bin.Length - 1; i >= 0; i--)
        {
            if (bin[i] == '1')
                dec += power;
            power *= 2;
        }

        Console.WriteLine("Decimal = " + dec);
    }
}
