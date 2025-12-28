using System;

// Input day/month/year and check if it's a valid calendar date (handle Feb 29).
static class ValidDateCheck
{
    public static void Execute()
    {
        Console.Write("Enter day: ");
        int day = int.Parse(Console.ReadLine());
        Console.Write("Enter month: ");
        int month = int.Parse(Console.ReadLine());
        Console.Write("Enter year: ");
        int year = int.Parse(Console.ReadLine());

        bool isLeap = (year % 400 == 0 || year % 4 == 0 && year % 100 != 0);
        int[] days = { 31, isLeap ? 29 : 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };

        if (month >= 1 && month <= 12 && day >= 1 && day <= days[month - 1])
            Console.WriteLine("Valid Date");
        else
            Console.WriteLine("Invalid Date");
    }
}
