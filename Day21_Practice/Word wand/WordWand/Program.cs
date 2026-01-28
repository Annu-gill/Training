using System;

class WordWand
{
    // Method to validate the sentence
    static bool IsValidSentence(string sentence)
    {
        foreach (char ch in sentence)
        {
            if (!(char.IsLetter(ch) || ch == ' '))
            {
                return false;
            }
        }
        return true;
    }

    // Method to reverse letters of each word
    static string ReverseLetters(string[] words)
    {
        string result = "";

        foreach (string word in words)
        {
            char[] chars = word.ToCharArray();
            Array.Reverse(chars);
            result += new string(chars) + " ";
        }

        return result.Trim();
    }

    // Method to reverse order of words
    static string ReverseWords(string[] words)
    {
        Array.Reverse(words);
        return string.Join(" ", words);
    }

    public static void Main()
    {
        Console.WriteLine("Enter the sentence");
        string sentence = Console.ReadLine();

        // Validate sentence
        if (!IsValidSentence(sentence))
        {
            Console.WriteLine("Invalid Sentence");
            return;
        }

        // Split words
        string[] words = sentence.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        int wordCount = words.Length;

        Console.WriteLine("Word Count: " + wordCount);

        string modifiedSentence;

        // Processing rules
        if (wordCount % 2 == 0)
        {
            // Even → reverse word order
            modifiedSentence = ReverseWords(words);
        }
        else
        {
            // Odd → reverse letters of each word
            modifiedSentence = ReverseLetters(words);
        }

        Console.WriteLine(modifiedSentence);
    }
}