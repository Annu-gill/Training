using System;

// Reverse an integer and check if it is palindrome using while
static class ReversePalindrome
{
    public static void Execute()
    {
        Console.Write("Enter number: ");
        int n = int.Parse(Console.ReadLine());

        int temp = n, rev = 0;
        while (temp > 0)
        {
            rev = rev * 10 + (temp % 10);
            temp /= 10;
        }

        Console.WriteLine("Reversed = " + rev);
        Console.WriteLine(rev == n ? "Palindrome" : "Not Palindrome");
    }
}
