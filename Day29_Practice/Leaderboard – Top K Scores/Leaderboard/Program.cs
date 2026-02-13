using System;
using System.Collections.Generic;
using System.Linq;

class LeaderboardTopK
{
    public static void Main()
    {
        List<(string name, int score)> players = new List<(string, int)>();

        Console.Write("Enter number of players: ");
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nPlayer {i + 1}:");

            Console.Write("Enter name: ");
            string name = Console.ReadLine();

            Console.Write("Enter score: ");
            int score = int.Parse(Console.ReadLine());

            players.Add((name, score));
        }

        Console.Write("\nEnter K (Top K players): ");
        int k = int.Parse(Console.ReadLine());

        List<(string name, int score)> topK = GetTopKPlayers(players, k);

        Console.WriteLine("\nTop K Leaderboard:");
        foreach (var p in topK)
        {
            Console.WriteLine($"{p.name} - {p.score}");
        }
    }

    static List<(string name, int score)> GetTopKPlayers(
        List<(string name, int score)> players, int k)
    {
        return players
                .OrderByDescending(p => p.score)   // Sort by score (desc)
                .ThenBy(p => p.name)               // Tie-breaker: name (asc)
                .Take(k)                           // Take top K
                .ToList();
    }
}
