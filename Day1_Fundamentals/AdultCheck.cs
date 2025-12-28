using System;

static class AdultCheck
{
    // check whether the person is adult or not
    public static void Execute()
    {
        Console.WriteLine("Enter age: ");
        string? input = Console.ReadLine();

        if (int.TryParse(input, out int age))
        {
            bool isAdult = age >= 18;
            Console.WriteLine("Adult? " + isAdult);
        }
        else
        {
            Console.WriteLine("Invalid age. please enter a whole number.");
        }
    }
}
