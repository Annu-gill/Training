using System;

class YourNameIsMine
{
    // Check if name contains only alphabets and spaces
    static bool IsValidName(string name)
    {
        foreach (char c in name)
        {
            if (!char.IsLetter(c) && c != ' ')
                return false;
        }
        return true;
    }

    // Check if s1 is a subsequence of s2
    static bool IsSubSequence(string s1, string s2)
    {
        int i = 0, j = 0;

        while (i < s1.Length && j < s2.Length)
        {
            if (char.ToLower(s1[i]) == char.ToLower(s2[j]))
                i++;
            j++;
        }
        return i == s1.Length;
    }

    // Edit Distance (Compatibility Value)
    static int GetCompatibilityValue(string s1, string s2)
    {
        int m = s1.Length;
        int n = s2.Length;

        int[,] dp = new int[m + 1, n + 1];

        for (int i = 0; i <= m; i++)
        {
            for (int j = 0; j <= n; j++)
            {
                if (i == 0)
                    dp[i, j] = j;
                else if (j == 0)
                    dp[i, j] = i;
                else if (char.ToLower(s1[i - 1]) == char.ToLower(s2[j - 1]))
                    dp[i, j] = dp[i - 1, j - 1];
                else
                    dp[i, j] = 1 + Math.Min(
                        dp[i - 1, j - 1],      // substitution
                        Math.Min(dp[i - 1, j], // deletion
                                 dp[i, j - 1]) // insertion
                    );
            }
        }
        return dp[m, n];
    }

    static void Main()
    {
        Console.WriteLine("Enter the man name");
        string manName = Console.ReadLine();

        Console.WriteLine("Enter the woman name");
        string womanName = Console.ReadLine();

        bool manValid = IsValidName(manName);
        bool womanValid = IsValidName(womanName);

        // Validation handling
        if (!manValid && !womanValid)
        {
            Console.WriteLine($"Both {manName} and {womanName} are invalid names");
            return;
        }
        if (!manValid)
        {
            Console.WriteLine($"{manName} is an invalid name");
            return;
        }
        if (!womanValid)
        {
            Console.WriteLine($"{womanName} is an invalid name");
            return;
        }

        // Remove spaces for logical comparison
        string m = manName.Replace(" ", "");
        string w = womanName.Replace(" ", "");

        int compatibilityValue = GetCompatibilityValue(m, w);

        bool madeForEachOther =
            IsSubSequence(m, w) ||
            IsSubSequence(w, m) ||
            compatibilityValue <= 3;

        if (!madeForEachOther)
        {
            Console.WriteLine($"{manName} and {womanName} are not made for each other");
            return;
        }

        Console.WriteLine($"{manName} and {womanName} are made for each other");
        Console.WriteLine("Compatibility Value is " + compatibilityValue);
    }
}