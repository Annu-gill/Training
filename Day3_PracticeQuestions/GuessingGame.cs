using System;

// Guessing game using do-while
static class GuessingGame
{
    public static void Execute()
    {
        int secret = 7, guess;

        do
        {
            Console.Write("Guess number (1-10): ");
            guess = int.Parse(Console.ReadLine());

        } while (guess != secret);

        Console.WriteLine("Correct Guess!");
    }
}
