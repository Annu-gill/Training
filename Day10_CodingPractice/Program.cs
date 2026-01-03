// using System;
// namespace Day10_CodingPractice
// {
//     class Program
//     {
//         public static void Main(string[] args)
//         {
//             ///<summary
//             /// checks whether it is a palindrome (using the extension method in `Palindrome.cs`),
//             // and prints the result to the console.
//             /// </summary>

//             // Prompt the user for input.
//             Console.WriteLine("Enter a string to check if it's a palindrome:");

//             string input = Console.ReadLine() ?? "";

//             // Use the 'IsPalindrome' extension method (defined in Day10_CodingPractice.Palindrome).
//             if (input.IsPalindrome())
//             {
//                 // Inform the user the input is a palindrome.
//                 Console.WriteLine($"\"{input}\" is a palindrome.");
//             }
//             else
//             {
//                 // Inform the user the input is not a palindrome.
//                 Console.WriteLine($"\"{input}\" is not a palindrome.");
//             }
//         }
//     }
// }



// using System;
// using System.Text.RegularExpressions;

// class Program
// {
//     static void Main()
//     {
//         string input = "Error: TIMEOUT while calling API";
//         string pattern = @"timeout";

//         var rx = new Regex(
//             pattern,
//             RegexOptions.IgnoreCase,
//             TimeSpan.FromMilliseconds(150) // match timeout
//         );

//         Console.WriteLine(rx.IsMatch(input) ? "Found" : "Not Found");
//     }
// }





// Garbage collector collects only managable code

// Garbage Collection Example
// using System;
// using System.Collections.Generic;   // Required for List<T>
// using Day10_CodingPractice;
// namespace Day10_CodingPractice
// {
//     public class Program
//     {
//         static void Main(string[] args)
//         {
//             // List that stores byte arrays
//             var list = new List<byte[]>();
//             Console.WriteLine("Memory before allocation: " + GC.GetTotalMemory(forceFullCollection: true));

//             for (int i = 0; i < 2000; i++)
//             {
//                 list.Add(new byte[1024]); // Allocate 1 KB blocks
//             }

//             Console.WriteLine("Allocated");
//             Console.WriteLine("Total memory: " + GC.GetTotalMemory(forceFullCollection: true));
//             GC.Collect(); // Force garbage collection
//             Console.WriteLine("Memory After GC: " + GC.GetTotalMemory(forceFullCollection: true));
//         }
//     }
// }






// using System;
// using System.Collections.Generic;   // Required for List<T>
// using Day10_CodingPractice;
// namespace Day10_CodingPractice
// {
//     public class Program
//     {
//         static void Main(string[] args)
//         {
//             BigBoy bigboy=new();
//             try{
//                 bigboy.Names=new System.Collections.ArrayList();
//                 for (int i=0;i<10;i++){
//                     bigboy.Names.Add(i.ToString());
//                 }

//             }
//             catch(System.Exception){
//                 throw;
//             }
//             finally{
//                 bigboy.Dispose();
//             }
//         }
//     }
// }




using System;
using System.Collections.Generic;   // Required for List<T>
using Day10_CodingPractice;
namespace Day10_CodingPractice
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyCollection M=new MyCollection();
            M.Add();
            M.Clear();
            // M.Contains();
            // M.CopyTo();
        }
    }
}