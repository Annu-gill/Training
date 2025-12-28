using System;

// Grade description using switch
static class GradeDescription
{
    public static void Execute()
    {
        Console.Write("Enter grade (E/V/G/A/F): ");
        char grade = Convert.ToChar(Console.ReadLine().ToUpper());

        switch (grade)
        {
            case 'E': Console.WriteLine("Excellent"); break;
            case 'V': Console.WriteLine("Very Good"); break;
            case 'G': Console.WriteLine("Good"); break;
            case 'A': Console.WriteLine("Average"); break;
            case 'F': Console.WriteLine("Fail"); break;
            default: Console.WriteLine("Invalid grade"); break;
        }
    }
}
