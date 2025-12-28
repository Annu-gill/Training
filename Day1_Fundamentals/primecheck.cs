using System;

namespace Day1
{
    /// <summary>
    /// Provides utilities to determine whether a number is even or odd.
    /// </summary>
    class CheckEvenorOdd
{ 
    /// <summary>
    /// Interactively checks numbers entered by the user and reports whether each is even or odd.
    /// </summary>
    /// <remarks>
    /// Reads input from the console repeatedly until the user enters 'q' or 'Q' to quit.
    /// </remarks>
    public static void Check()
    {
        // Prompt user for initial input
        Console.WriteLine("Enter the Number to find Even or Odd or ('q' to quit)");

        #region Variables
        // Stores the user's input choice (number or quit instruction)
        String? choice = Console.ReadLine();
        // Holds the computed result label ("Even" or "Odd")
        String checkresult = String.Empty;
        // Parsed numeric value from the input
        int number = 0;
        #endregion

        #region Method Logic
        // Continue reading and evaluating numbers until the user chooses to quit
        while (!(choice == "q" || choice == "Q"))
        {
            // Parse input safely; default to 0 if invalid
            number = int.TryParse(choice, out number) ? number : 0;

            // Determine parity using helper method
            checkresult = IsEven(number) ? "Even" : "Odd";
            Console.WriteLine(checkresult);

            // Prompt again for next input or to quit
            Console.WriteLine("Enter the Number to find Even or Odd or ('q' to quit)");
            choice = Console.ReadLine();
        }
        #endregion
    }
    /// <summary>
    /// Determines whether the specified number is even.
    /// </summary>
    /// <param name="number">The integer value to check.</param>
    /// <returns><c>true</c> if the number is even; otherwise, <c>false</c>.</returns>
    static bool IsEven(int number)
    {
        #region Method Logic
        // A number is even if divisible by 2 without remainder
        return number % 2 == 0;
        #endregion
    }
}
}