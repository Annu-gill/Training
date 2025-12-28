// using System;

// class Program
// {
//     public static string CleanseAndInvert(string input)
//     {
//         // return empty string if the input string is null or length < 6
//         if (string.IsNullOrEmpty(input) || input.Length < 6)
//             return string.Empty;

//         // only alphabets allowed
//         foreach (char ch in input)
//         {
//             if (!char.IsLetter(ch))
//                 return string.Empty;
//         }

//         // Convert to lowercase
//         input = input.ToLower();

//         // Remove characters with even ASCII values
//         char[] temp = new char[input.Length];
//         int index = 0;

//         foreach (char ch in input)
//         {
//             if ((int)ch % 2 != 0)   // keep odd ASCII
//             {
//                 temp[index++] = ch;
//             }
//         }

//         // Create array with exact size
//         char[] filtered = new char[index];
//         Array.Copy(temp, filtered, index);

//         // Reverse the array
//         Array.Reverse(filtered);

//         // Uppercasing the even index characters
//         for (int i = 0; i < filtered.Length; i++)
//         {
//             if (i % 2 == 0)
//             {
//                 filtered[i] = char.ToUpper(filtered[i]);
//             }
//         }

//         return new string(filtered);
//     }

//     public static void Main()
//     {
//         Console.WriteLine("Enter the word");
//         string input=Console.ReadLine();
//         string result=CleanseAndInvert(input);

//         // if the input string is null, print invalid input, else print the result
//         if (string.IsNullOrEmpty(result))
//         {
//             Console.WriteLine("Invalid Input");
//         }
//         else
//         {
//             Console.WriteLine("The generated key is - " + result);
//         }
//     }
// }


// using System;

// class Program
// {
//     static void Main()
//     {
//         int[][] data = new int[5][];
//         data[0] = new int[] { 1, 2, 3 };
//         data[1] = new int[] { 10, 20 };
//         data[2] = new int[] { 7, 8, 9, 10 };
//         data[3] = new int[] { 20, 40 };
//         data[4] = new int[] { 11, 18, 19, 30 };

//         for (int i = 0; i < data.Length; i++)
//         {
//             Console.Write("Row " + i + ": ");
//             foreach (var v in data[i]) Console.Write(v + " ");
//             Console.WriteLine();
//         }
//     }
// }


using System;
using System.Collections;
using System.Collections.Generic;

namespace Day7ScenarioBased
{
    public class Collections
    {
        public void Sample1()
        {
            // Non-generic collection: can hold any object type
            ArrayList myList = new ArrayList();
            myList.Add(10);       // integer
            myList.Add("Hello");
            myList.Add(25.5);     // double

            // Iterate and print each item (boxing/unboxing may occur)
            foreach (var item in myList)
            {
                System.Console.WriteLine(item);
            }

            // Stack example (LIFO)
            Stack myStack = new Stack();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push("Stack Item");
            myStack.Pop(); // removes the top item

            // Queue example (FIFO)
            Queue q = new Queue();
            q.Enqueue("First");
            q.Enqueue(2);
            q.Enqueue(3.5);
            q.Dequeue(); // removes the first enqueued item

            // Generics example: type-safe list of strings
            List<string> names = new List<string>();
            names.Add("Alice");
            names.Add("Charlie");
            names.Add("Bob");

            // Sort alphabetically and print
            names.Sort();
            foreach (var name in names)
            {
                System.Console.WriteLine(name);
            }
        }

        public static void Main()
        {
            Collections col = new();
            col.Sample1();
        }
    }
}




