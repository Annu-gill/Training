using System;

class PasswordGeneration
{
    static bool IsValidUsername(string username)
    {
        // Length check
        if (username.Length != 8)
            return false;

        // First 4 characters must be uppercase alphabets
        for (int i = 0; i < 4; i++)
        {
            if (!char.IsUpper(username[i]))
                return false;
        }

        // 5th character must be '@'
        if (username[4] != '@')
            return false;

        // Last 3 characters must be digits
        for (int i = 5; i < 8; i++)
        {
            if (!char.IsDigit(username[i]))
                return false;
        }

        // Course ID range check
        int courseId = int.Parse(username.Substring(5, 3));
        if (courseId < 101 || courseId > 115)
            return false;

        return true;
    }

    static void Main()
    {
        Console.WriteLine("Enter the username");
        string username = Console.ReadLine();

        if (!IsValidUsername(username))
        {
            Console.WriteLine(username + " is an invalid username");
            return;
        }

        // Convert first 4 characters to lowercase and calculate ASCII sum
        int asciiSum = 0;
        for (int i = 0; i < 4; i++)
        {
            char lowerChar = char.ToLower(username[i]);
            asciiSum += (int)lowerChar;
        }

        // Get last 2 digits of course ID
        string lastTwoDigits = username.Substring(6, 2);

        // Generate password
        string password = "TECH_" + asciiSum + lastTwoDigits;

        Console.WriteLine("Password: " + password);
    }
}