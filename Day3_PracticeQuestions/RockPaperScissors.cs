using System;

// Logic for a 2-player Rock Paper Scissors game using nested conditionals
static class RockPaperScissors
{
    public static void Execute()
    {
        Console.Write("Player 1 (rock/paper/scissors): ");
        string p1 = Console.ReadLine().ToLower();

        Console.Write("Player 2 (rock/paper/scissors): ");
        string p2 = Console.ReadLine().ToLower();

        if (p1 == p2)
        {
            Console.WriteLine("Draw");
        }
        else if (p1 == "rock")
        {
            if (p2 == "scissors") Console.WriteLine("Player 1 Wins");
            else Console.WriteLine("Player 2 Wins");
        }
        else if (p1 == "paper")
        {
            if (p2 == "rock") Console.WriteLine("Player 1 Wins");
            else Console.WriteLine("Player 2 Wins");
        }
        else if (p1 == "scissors")
        {
            if (p2 == "paper") Console.WriteLine("Player 1 Wins");
            else Console.WriteLine("Player 2 Wins");
        }
        else
        {
            Console.WriteLine("Invalid Input");
        }
    }
}
