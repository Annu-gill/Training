using System;

// Print Pascal's Triangle using nested loops
static class PascalsTriangle
{
    public static void Execute()
    {
        Console.Write("Enter number of rows: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            int val = 1;
            for (int j = 0; j <= i; j++)
            {
                Console.Write(val + " ");
                val = val * (i - j) / (j + 1);
            }
            Console.WriteLine();
        }
    }
}
