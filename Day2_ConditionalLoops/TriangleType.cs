using System;

// Determine triangle type
static class TriangleType
{
    public static void Execute()
    {
        Console.Write("Enter first side: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter second side: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter third side: ");
        int c = Convert.ToInt32(Console.ReadLine());

        if (a + b > c && a + c > b && b + c > a)
        {
            if (a == b && b == c)
                Console.WriteLine("Equilateral Triangle");
            else if (a == b || b == c || a == c)
                Console.WriteLine("Isosceles Triangle");
            else
                Console.WriteLine("Scalene Triangle");
        }
        else
            Console.WriteLine("Invalid triangle");
    }
}
