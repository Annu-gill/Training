using System;

// Find quadrant of a point
static class QuadrantFinder
{
    public static void Execute()
    {
        Console.Write("Enter X: ");
        int x = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Y: ");
        int y = Convert.ToInt32(Console.ReadLine());

        if (x > 0 && y > 0) Console.WriteLine("First Quadrant");
        else if (x < 0 && y > 0) Console.WriteLine("Second Quadrant");
        else if (x < 0 && y < 0) Console.WriteLine("Third Quadrant");
        else if (x > 0 && y < 0) Console.WriteLine("Fourth Quadrant");
        else if (x == 0 && y == 0) Console.WriteLine("Origin");
        else if (x == 0) Console.WriteLine("On Y-axis");
        else Console.WriteLine("On X-axis");
    }
}
