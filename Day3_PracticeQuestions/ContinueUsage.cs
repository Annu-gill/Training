using System;

// Print 1 to 50 skipping multiples of 3 using continue
static class ContinueUsage
{
    public static void Execute()
    {
        for (int i = 1; i <= 50; i++)
        {
            if (i % 3 == 0)
                continue;

            Console.Write(i + " ");
        }
    }
}
