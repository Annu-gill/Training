using System;
using System.Collections.Generic;

public class InvalidEntryException : Exception
{
    public InvalidEntryException(string message) : base(message)
    {
    }
}

public class EntryUtility
{
    // Validate Employee ID
    public bool validateEmployeeId(string employeeId)
    {
        // Must be GOAIR/XXXX (10 characters)
        if (employeeId.Length != 10)
            throw new InvalidEntryException("Invalid entry details");

        if (!employeeId.StartsWith("GOAIR/"))
            throw new InvalidEntryException("Invalid entry details");

        for (int i = 6; i < 10; i++)
        {
            if (!char.IsDigit(employeeId[i]))
                throw new InvalidEntryException("Invalid entry details");
        }

        return true;
    }

    // Validate Duration
    public bool validateDuration(int duration)
    {
        if (duration < 1 || duration > 5)
            throw new InvalidEntryException("Invalid entry details");

        return true;
    }
}

public class UserInterface
{
    public static void Main()
    {
        EntryUtility utility = new EntryUtility();
        List<string> results = new List<string>();

        Console.WriteLine("Enter the number of entries");
        int n = int.Parse(Console.ReadLine());

        string[] inputs = new string[n];

        // Step 1: Take all inputs first
        for (int i = 1; i <= n; i++)
        {
            Console.WriteLine($"Enter entry {i} details");
            inputs[i - 1] = Console.ReadLine();
        }
        Console.WriteLine(" ");

        // Step 2: Process validations
        foreach (string input in inputs)
        {
            try
            {
                string[] parts = input.Split(':');
                string employeeId = parts[0];
                int duration = int.Parse(parts[2]);

                utility.validateEmployeeId(employeeId);
                utility.validateDuration(duration);

                results.Add("Valid entry details");
            }
            catch (InvalidEntryException)
            {
                results.Add("Invalid entry details");
            }
        }

        // Step 3: Print outputs
        foreach (string result in results)
        {
            Console.WriteLine(result);
        }
    }
}