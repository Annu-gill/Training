using System;

// Leap Year Checker: Determine if a year is leap (Divisible by 400 OR (Divisible by 4 and NOT 100)).
static class LeapYearChecker
{
    public static void Execute()
    {
        Console.Write("Enter year: ");
        int year = Convert.ToInt32(Console.ReadLine());

        if (year % 400 == 0 || (year % 4 == 0 && year % 100 != 0))
            Console.WriteLine(year + " is a Leap Year");
        else
            Console.WriteLine(year + " is not a Leap Year");
    }
}
