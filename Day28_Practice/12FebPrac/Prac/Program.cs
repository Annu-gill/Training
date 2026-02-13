// // 1. Reverse a string without using built-in functions.

// using System;
// class Program
// {
//     public static void Main()
//     {
//         Console.Write("Enter the string: ");
//         string input=Console.ReadLine();
//         char[] reversed = new char[input.Length];
//         for (int i = 0; i < input.Length;i++)
//         {
//             reversed[i]=input[input.Length-i-1];

//         }
//         Console.WriteLine("Reversed string is: "+new string(reversed));
//     }
// }


// // 2. Find the largest element in an integer array.
// using System;
// using System;

// class Program
// {
//     public static void Main()
//     {
//         Console.Write("Enter the number of elements: ");
//         int n = int.Parse(Console.ReadLine() ?? " ");
//         int[] numbers = new int[n];

//         for (int i = 0; i < n; i++)
//         {
//             Console.Write($"Enter element {i + 1}: ");
//             numbers[i] = int.Parse(Console.ReadLine() ?? "" );
//         }

//         // Finding largest element using foreach
//         int max = numbers[0];
//         foreach (int num in numbers)
//         {
//             if (num > max)
//             {
//                 max = num;
//             }
//         }

//         Console.WriteLine($"Largest number: {max}");
//     }
// }


// // 3. Remove duplicates from a list using a HashSet.

// using System;
// using System.Collections.Generic;
// class Program
// {
//     public static void Main()
//     {
//         Console.Write("Enter number of elements: ");
//         int n = int.Parse(Console.ReadLine());

//         List<int> numbers = new List<int>();

//         // Taking user input
//         for (int i = 0; i < n; i++)
//         {
//             Console.Write($"Enter element {i + 1}: ");
//             numbers.Add(int.Parse(Console.ReadLine()));
//         }

//         // Remove duplicates using HashSet
//         HashSet<int> uniqueNumbers = new HashSet<int>(numbers);

//         Console.WriteLine("After removing duplicates:");
//         Console.WriteLine(string.Join(", ", uniqueNumbers));
//     }
// }


// // 4. Find the frequency of elements in an array using a Dictionary.

// using System;
// using System.Collections.Generic;

// class Program
// {
//     public static void Main()
//     {
//         Console.Write("Enter number of elements: ");
//         int n = int.Parse(Console.ReadLine());

//         int[] arr = new int[n];

//         //  user input
//         for (int i = 0; i < n; i++)
//         {
//             Console.Write($"Enter element {i + 1}: ");
//             arr[i] = int.Parse(Console.ReadLine());
//         }

//         // Dictionary to store frequency
//         Dictionary<int, int> freq = new Dictionary<int, int>();

//         // Counting frequency using foreach
//         foreach (int num in arr)
//         {
//             if (freq.ContainsKey(num))
//                 freq[num]++;
//             else
//                 freq[num] = 1;
//         }

//         // Display result
//         Console.WriteLine("\nElement : Frequency");
//         foreach (var item in freq)
//         {
//             Console.WriteLine($"{item.Key} : {item.Value}");
//         }
//     }
// }


// // 5. Check if a given string is a palindrome.

// using System;
// class Program {
//     static void Main() {
//         Console.WriteLine("Enter the string input");
//         string input = Console.ReadLine();
//         bool isPalindrome = true;
//         for (int i = 0; i < input.Length / 2; i++) {
//             if (input[i] != input[input.Length - 1 - i]) {
//             isPalindrome = false;
//                 break;
//             }
//     }
//         Console.WriteLine(isPalindrome ? "Palindrome" : "Not a palindrome");
//     }
// }


// // 6. Find the sum of all elements in an array.

// using System;
// class Program {
//     public static void Main() {
//         int[] arr = {1, 2, 3, 4, 5};
//         int sum = 0;
//         foreach(int num in arr) sum += num;
//         Console.WriteLine("Sum: {sum}");
//     }
// }


// 7. Merge two sorted arrays into a single sorted array.

using System;
using System.Linq;
class Program {
    static void Main() {
        int[] arr1 = {1, 3, 5};
        int[] arr2 = {2, 4, 6};
        int[] merged = new int[arr1.Length + arr2.Length];
        int i = 0, j = 0, k = 0;
        while (i < arr1.Length && j < arr2.Length) {
            if (arr1[i] < arr2[j]) {
                merged[k++] = arr1[i++];
            } else {
                merged[k++] = arr2[j++];
            }
        }
        while (i < arr1.Length) {
            merged[k++] = arr1[i++];
        }
        while (j < arr2.Length) {
            merged[k++] = arr2[j++];
        }
        Console.WriteLine(string.Join(", ", merged));
    }
}