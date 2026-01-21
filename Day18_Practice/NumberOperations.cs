// Question 3: 

using System;
using System.Collections.Generic;

namespace Day18_Practice
{
    public class NumberOperations
    {
        // Provided list in template
        public static List<int> NumberList = new List<int>();

        // Add numbers to the list
        public static void AddNumbers(int number)
        {
            NumberList.Add(number);
        }

        // Calculate GPA
        public static double GetGPAScored()
        {
            if (NumberList.Count == 0)
            {
                return -1;
            }

            int creditPoint = 3;
            int totalCredits = NumberList.Count * creditPoint;
            int totalScore = 0;

            foreach (int num in NumberList)
            {
                totalScore += num * creditPoint;
            }

            return (double)totalScore / totalCredits;
        }

        // Get Grade based on GPA
        public static char GetGradeScored(double gpa)
        {
            char result=' ';
            if (gpa < 5 || gpa > 10)
            {
                return '\0'; // null character
            }

            if (gpa == 10) return 'S';
            if (gpa >= 9) return 'A';
            if (gpa >= 8) return 'B';
            if (gpa >= 7) return 'C';
            if (gpa >= 6) return 'D';
            return 'E';
        }
    }
}
