using System;
using System.Collections.Generic;
using System.Linq;

public class CreatorStats
{
    public string CreatorName { get; set; }
    public double[] WeeklyLikes { get; set; }
}

public class Program
{
    // Stores all creator engagement records
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    /// <summary>
    /// Adds a creator's engagement record to the EngagementBoard list.
    /// </summary>
    public void RegisterCreator(CreatorStats record)
    {
        // Add the creator record to the list
        EngagementBoard.Add(record);
    }

    /// <summary>
    /// Calculates the number of weeks each creator's likes
    /// are greater than or equal to the specified threshold.
    /// </summary>
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        // Dictionary to store the result
        Dictionary<string, int> result = new Dictionary<string, int>();

        // Iterate through each creator record
        foreach (var creator in records)
        {
            // Count weeks where likes meet or exceed the threshold
            int count = creator.WeeklyLikes.Count(like => like >= likeThreshold);

            // Add to result only if the creator qualifies at least once
            if (count > 0)
            {
                result.Add(creator.CreatorName, count);
            }
        }

        return result;
    }

    /// <summary>
    /// Calculates and returns the average weekly likes
    /// across all registered creators.
    /// </summary>
    /// <returns>Average value of all weekly likes</returns>
    public double CalculateAverageLikes()
    {
        // If no creators are registered, return 0
        if (EngagementBoard.Count == 0)
            return 0;

        double totalLikes = 0;
        int totalWeeks = 0;

        // Iterate through all creators
        foreach (var creator in EngagementBoard)
        {
            // Sum all weekly likes
            foreach (var like in creator.WeeklyLikes)
            {
                totalLikes += like;
                totalWeeks++;
            }
        }

        // Calculate and return the average
        return totalLikes / totalWeeks;
    }

    /// <summary>
    /// Entry point of the StreamBuzz console application.
    /// Handles user input and invokes required functionalities.
    /// </summary>
    public static void Main()
    {
        Program program = new Program();
        bool running = true;

        // Continue execution until the user chooses to exit
        while (running)
        {
            Console.WriteLine("\n1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    // Read creator name
                    Console.WriteLine("Enter Creator Name:");
                    string name = Console.ReadLine();

                    // Read weekly likes for four weeks
                    double[] likes = new double[4];
                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    for (int i = 0; i < 4; i++)
                    {
                        likes[i] = double.Parse(Console.ReadLine());
                    }

                    // Create creator record
                    CreatorStats creator = new CreatorStats
                    {
                        CreatorName = name,
                        WeeklyLikes = likes
                    };

                    // Register creator
                    program.RegisterCreator(creator);
                    Console.WriteLine("Creator registered successfully");
                    break;

                case 2:
                    // Read like threshold value
                    Console.WriteLine("Enter like threshold:");
                    double threshold = double.Parse(Console.ReadLine());

                    // Get top-performing post counts
                    var topPosts = program.GetTopPostCounts(EngagementBoard, threshold);

                    // Display result
                    if (topPosts.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach (var item in topPosts)
                        {
                            Console.WriteLine(item.Key + " - " + item.Value);
                        }
                    }
                    break;

                case 3:
                    // Calculate and display average likes
                    double average = program.CalculateAverageLikes();
                    Console.WriteLine("Overall average weekly likes: " + average);
                    break;

                case 4:
                    // Exit the application
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    running = false;
                    break;
            }
        }
    }
}
