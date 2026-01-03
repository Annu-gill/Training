using System;
namespace Day10_CodingPractice
{
    /// <summary>
    /// Utility class containing palindrome-related helper methods.
    /// </summary>
    public static class Palindrome
    {
        /// <summary>
        /// Determines whether the specified string is a palindrome.
        /// "this" is implemented as an extension method.
        /// </summary>
        public static bool IsPalindrome(this string str)
        {
            if (string.IsNullOrEmpty(str))
                return false;
            // Initialize two indices pointing to the start and end of the string.
            int left = 0;
            int right = str.Length - 1;

            // Move the indices towards the center while comparing characters.
            while (left < right)
            {
                // If any corresponding characters differ, it's not a palindrome.
                if (str[left] != str[right])
                {
                    return false;
                }

                // Move inward from both sides.
                left++;
                right--;
            }

            // All character pairs matched — the string is a palindrome.
            return true;
        }
    }
}



