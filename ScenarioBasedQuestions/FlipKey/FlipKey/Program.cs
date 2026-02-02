using System;

public class Program
{
    /// <summary>
    /// This program accepts a word from the user and generates a key.
    /// It validates the input, removes characters with even ASCII values,
    /// reverses the remaining characters, and converts alternate characters
    /// to uppercase. If the input is invalid, it displays an error message.
    /// </summary>

    public static string CleanseAndInvert(string input)
    {
        // return empty string if the input string is null or length < 6
        if (string.IsNullOrEmpty(input) || input.Length < 6)
            return string.Empty;

        // only alphabets allowed
        foreach (char ch in input)
        {
            if (!char.IsLetter(ch))
                return string.Empty;
        }

        // Convert to lowercase
        input = input.ToLower();

        // Remove characters with even ASCII values
        char[] temp = new char[input.Length];
        int index = 0;

        foreach (char ch in input)
        {
            if ((int)ch % 2 != 0)   // keep odd ASCII
            {
                temp[index++] = ch;
            }
        }

        // Create array with exact size
        char[] filtered = new char[index];
        Array.Copy(temp, filtered, index);

        // Reverse the array
        Array.Reverse(filtered);

        // Uppercasing the even index characters
        for (int i = 0; i < filtered.Length; i++)
        {
            if (i % 2 == 0)
            {
                filtered[i] = char.ToUpper(filtered[i]);
            }
        }

        return new string(filtered);
    }

    public static void Main()
    {
        Console.WriteLine("Enter the word");
        string input = Console.ReadLine();
        string result = CleanseAndInvert(input);

        // if the input string is null, print invalid input, else print the result
        if (string.IsNullOrEmpty(result))
        {
            Console.WriteLine("Invalid Input");
        }
        else
        {
            Console.WriteLine("The generated key is - " + result);
        }
    }
}
