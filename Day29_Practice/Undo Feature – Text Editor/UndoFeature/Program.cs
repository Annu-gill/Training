using System;
using System.Collections.Generic;

class TextEditorUndo
{
    public static void Main()
    {
        List<string> ops = new List<string>();

        Console.Write("Enter number of operations: ");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter operations (TYPE <word> / UNDO):");

        for (int i = 0; i < n; i++)
        {
            ops.Add(Console.ReadLine());
        }

        string finalText = ProcessOperations(ops);

        Console.WriteLine("\nFinal Text:");
        Console.WriteLine(finalText);
    }

    static string ProcessOperations(List<string> ops)
    {
        Stack<string> stack = new Stack<string>();

        foreach (string op in ops)
        {
            // TYPE operation
            if (op.StartsWith("TYPE "))
            {
                string word = op.Substring(5); // Extract word
                stack.Push(word);
            }
            // UNDO operation
            else if (op == "UNDO")
            {
                if (stack.Count > 0)
                    stack.Pop(); // Remove last typed word
            }
        }

        // Build final text in correct order
        string[] words = stack.ToArray();
        Array.Reverse(words);

        return string.Join(" ", words);
    }
}
