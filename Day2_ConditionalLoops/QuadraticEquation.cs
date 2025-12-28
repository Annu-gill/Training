using System;

// Quadratic Equation: Calculate roots of ax^2 + bx + c = 0 using discriminant
static class QuadraticEquation
{
    public static void Execute()
    {
        Console.Write("Enter a: ");
        double a = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter b: ");
        double b = Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter c: ");
        double c = Convert.ToDouble(Console.ReadLine());

        if (a == 0)
        {
            Console.WriteLine("Not a quadratic equation");
            return;
        }

        double d = b * b - 4 * a * c;

        if (d > 0)
        {
            double r1 = (-b + Math.Sqrt(d)) / (2 * a);
            double r2 = (-b - Math.Sqrt(d)) / (2 * a);
            Console.WriteLine("Roots are: " + r1 + " and " + r2);
        }
        else if (d == 0)
        {
            double r = -b / (2 * a);
            Console.WriteLine("Roots are equal: " + r);
        }
        else
        {
            Console.WriteLine("Roots do not exist");
        }
    }
}
