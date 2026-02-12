// // using System;

// // namespace Practice
// // {
// //     public class Employee
// //     {
// //         public int Id{get; set;}
// //         public string Name{get;set;}
// //         public int Salary{get;set;}
// //         public void Display()
// //         {
// //             Console.WriteLine($"Id: "+Id+"Name: "+Name+"Salary: ");

// //         }

// //     }
// //     public class Program
// //     {
// //         public static void Main(string[] args)
// //         {
// //             Employee emp=new Employee(1, "Annu",100000);
// //         }
// //     }
// // }


// // // generics

// // using System;
// // using System.Collections.Generic;

// // class Program
// // {
// //     public static void Main()
// //     {
// //         List<int> numbers = new List<int>();
// //         numbers.Add(100);
// //         numbers.Add(200);

// //         foreach (int num in numbers)
// //         {
// //             Console.WriteLine(num);
// //         }
// //     }
// // }

// // Non-generic

// // using System;
// // using System.Collections;

// // class Program
// // {
// //     public static void Main()
// //     {
// //         ArrayList list = new ArrayList();
// //         list.Add(100);
// //         list.Add("Hello");

// //         foreach (object item in list)
// //         {
// //             Console.WriteLine(item);
// //         }
// //     }
// // }



// // using System;
// // using System.Collections.Generic;

// // public class Program
// // {
// //     public static void Main(string[] args)
// //     {
// //         Console.WriteLine("Enter String: ");
// //         string string1 = Console.ReadLine();

// //         SortedDictionary<char, int> freq = new SortedDictionary<char, int>();

// //         foreach (char item in string1)
// //         {
// //             if (freq.ContainsKey(item))
// //             {
// //                 freq[item] += 1;
// //             }
// //             else
// //             {
// //                 freq[item] = 1;
// //             }
// //         }

// //         foreach (var item in freq)
// //         {
// //             Console.WriteLine($"{item.Key} : {item.Value}");
// //         }
// //     }
// // }




// using System;
// using System.Collections.Generic;

// public class Program
// {
//     public static void Main()
//     {
//         Console.Write("Enter word1: ");
//         string word1 = Console.ReadLine();

//         Console.Write("Enter word2: ");
//         string word2 = Console.ReadLine();

//         Dictionary<char, int> freq1 = new Dictionary<char, int>();
//         Dictionary<char, int> freq2 = new Dictionary<char, int>();

//         foreach (char c in word1)
//             freq1[c] = freq1.ContainsKey(c) ? freq1[c] + 1 : 1;

//         foreach (char c in word2)
//             freq2[c] = freq2.ContainsKey(c) ? freq2[c] + 1 : 1;

//         int deletions = 0;

//         HashSet<char> allChars = new HashSet<char>(freq1.Keys);     // hashset - avoid duplicates
//         allChars.UnionWith(freq2.Keys);                             // unionwith - add missing charac

//         foreach (char c in allChars)
//         {
//             int count1 = freq1.ContainsKey(c) ? freq1[c] : 0;
//             int count2 = freq2.ContainsKey(c) ? freq2[c] : 0;

//             deletions += Math.Abs(count1 - count2);
//         }

//         Console.WriteLine("Deletions required: " + deletions);
//     }
// }

using System;
using System.Collections.Generic;

public class Employee {
    public int employeeID;
    public string designation;

    public Employee(int employeeID, string designation) {
        this.employeeID = employeeID;
        this.designation = designation;
    }
}

public class EmployeeManagement {
    // Map to store Employee objects by ID
    private Dictionary<int, Employee> employees = new Dictionary<int, Employee>();

    public void AddEmployee(int employeeID, string designation) {
        if (!employees.ContainsKey(employeeID)) {
            employees.Add(employeeID, new Employee(employeeID, designation));
        }
    }

    public void UpdateDesignation(int employeeID, string newDesignation) {
        if (employees.ContainsKey(employeeID)) {
            employees[employeeID].designation = newDesignation;
            Console.WriteLine($"{employeeID} {newDesignation}");
        }
    }
}



// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;

// public class StringTransformer {
//     public static string ProcessString(string str, int k) {
//         // 1. Reverse the string
//         char[] charArray = str.ToCharArray();
//         Array.Reverse(charArray);
//         string reversed = new string(charArray);

//         // 2 & 3. Replace vowels (case-insensitive, preserve case)
//         string vowels = "aeiou";
//         StringBuilder vowelStep = new StringBuilder();
//         foreach (char c in reversed) {
//             char lowerC = char.ToLower(c);
//             int index = vowels.IndexOf(lowerC);
//             if (index != -1) {
//                 // Find next vowel in sequence (cyclic)
//                 char nextVowel = vowels[(index + 1) % 5];
//                 // Preserve original case
//                 vowelStep.Append(char.IsUpper(c) ? char.ToUpper(nextVowel) : nextVowel);
//             } else {
//                 vowelStep.Append(c);
//             }
//         }

//         // 4. Remove duplicates (keep first occurrence)
//         StringBuilder uniqueStep = new StringBuilder();
//         HashSet<char> seen = new HashSet<char>();
//         foreach (char c in vowelStep.ToString()) {
//             if (!seen.Contains(c)) {
//                 uniqueStep.Append(c);
//                 seen.Add(c);
//             }
//         }

//         // 5. Rotate right by K
//         string s = uniqueStep.ToString();
//         if (string.IsNullOrEmpty(s)) return s;
        
//         int n = s.Length;
//         int rotation = k % n; // Handle k > length
//         if (rotation == 0) return s;

//         string rotated = s.Substring(n - rotation) + s.Substring(0, n - rotation);
//         return rotated;
//     }
// }