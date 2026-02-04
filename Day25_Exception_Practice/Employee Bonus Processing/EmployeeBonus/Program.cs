using System;

class BonusCalculator
{
    public static void Main()
    {
        int[] salaries = { 5000, 0, 7000 };
        int bonus = 10000;

        // 1. Loop through salaries
        for (int i = 0; i < salaries.Length; i++)
        {
            try
            {
                // 2. Divide bonus by salary
                int result = bonus / salaries[i];
                Console.WriteLine($"Employee {i + 1} bonus factor: {result}");
            }
            catch (DivideByZeroException)
            {
                // 3. Handle divide by zero exception
                Console.WriteLine($"Employee {i + 1}: Salary is zero. Cannot calculate bonus.");
            }
            finally
            {
                // 4. Continue processing remaining employees
                Console.WriteLine($"Processed employee {i + 1}");
            }
        }

        Console.WriteLine("Bonus processing completed for all employees.");
    }
}
