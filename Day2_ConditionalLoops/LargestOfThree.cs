using System;

// Largest of Three: Take three integers and find the maximum using nested if.
static class LargestOfThree
{
    public static void Execute()
    {
        Console.Write("Enter first number: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second number: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter third number: ");
        int c = Convert.ToInt32(Console.ReadLine());

        if (a > b)
        {
            if (a > c)
                Console.WriteLine("Largest number is: " + a);
            else
                Console.WriteLine("Largest number is: " + c);
        }
        else
        {
            if (b > c)
                Console.WriteLine("Largest number is: " + b);
            else
                Console.WriteLine("Largest number is: " + c);
        }
    }
}
