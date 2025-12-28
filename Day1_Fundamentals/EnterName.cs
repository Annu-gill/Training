using System;

static class EnterName
{
    // enter your name and print it
    public static void Execute()
    {
        Console.WriteLine("Enter your name: ");
        string? name = Console.ReadLine();
        Console.WriteLine("Hello, " + name + "!");
    }
}
