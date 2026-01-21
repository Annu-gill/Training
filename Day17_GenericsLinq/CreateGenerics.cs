// // using Generics;

// // namespace Generics
// // {
// //     public class Student
// //     {
// //         public string? Name {get;set;}
// //     }
// //     public class UGStudent : Student
// //     {
// //         public int HighSchoolMarks {get;set;}
// //     }
// //     public class PGStudent : Student
// //     {
// //         public int UGMarks {get;set;}
// //     }
// //     public class MyGlobalType<T>
// //     {
// //         public string GetDataType(T t)
// //         {
// //             return typeof(T).Name;
// //         }
// //     }
// // } 

// // namespace Day17_GenericsLinq
// // {
// //     public class CallerClass
// //     {
// //         public static void Main()
// //         {
// //             MyGlobalType<UGStudent> myGlobalType = new();
// //             UGStudent obj = new ();
// //             string result = myGlobalType.GetDataType(obj);
// //             System.Console.WriteLine(result);
// //         }
// //     }
// // }



// // using System;

// // namespace Generics
// // {
// //     // Base class
// //     public class Student
// //     {
// //         public string? Name { get; set; }
// //     }

// //     // Derived classes
// //     public class UGStudent : Student
// //     {
// //         public int HighSchoolMarks { get; set; }
// //     }

// //     public class PGStudent : Student
// //     {
// //         public int UGMarks { get; set; }
// //     }

// //     // Generic class with TWO type parameters
// //     public class MyGlobalType<T1, T2>
// //     {
// //         public string GetDataTypes(T1 obj1, T2 obj2)
// //         {
// //             return $"First Type: {typeof(T1).Name}, Second Type: {typeof(T2).Name}";
// //         }
// //     }
// // }

// // namespace Day17_GenericsLinq
// // {
// //     using Generics;

// //     public class CallerClass
// //     {
// //         public static void Main()
// //         {
// //             // Using two different data types
// //             MyGlobalType<UGStudent, PGStudent> myGlobalType = new();

// //             UGStudent ug = new();
// //             PGStudent pg = new();

// //             string result = myGlobalType.GetDataTypes(ug, pg);
// //             Console.WriteLine(result);
// //         }
// //     }
// // }


// // from generics we can't go for properties


// using System;

// namespace Generics
// {
//     public class Object
//     {
//         public string? ObjName { get; set; }
//     }
//     public class Student
//     {
//         public string? Name { get; set; }
//     }

//     public class UGStudent : Student
//     {
//         public int HighSchoolMarks { get; set; }
//     }

//     public class MyGlobalType<T, K>
//     {
//         public string GetDataType(T t, K k)
//         {
//             return typeof(T).Name + typeof(K).Name;
//         }
//     }
// }

// namespace Day17_GenericsLinq
// {
//     using Generics;

//     public class CallerClass
//     {
//         public static void Main()
//         {
//             UGStudent ugStudent = new();
//             Object obj = new();

//             MyGlobalType<UGStudent, Object> myGlobalType = new();

//             var result = myGlobalType.GetDataType(ugStudent,obj);
//             Console.WriteLine(result);

//             Predicate<int> isEven=number=>number%2==0;
//             bool check=isEven(10);
//             Console.WriteLine("The number is Even: "+check);

//             // Action...
//             // Use Case: For methods that return 'void'
//             // Often used for logging, printing, or updating UI.
//             Action<string> logger=message =>
//             {
//                 Console.WriteLine($"[LOG]: {message} at {DateTime.Now}");
//             };
//             logger("Application Started");  // Invoking the Action



//             Func<int, int, string> multiplyResult = (x,y) => 
//             {
//                 return $"{x} * {y} is {x*y}";
//             };
//             var res = multiplyResult(4,5);
//             System.Console.WriteLine(res);

//         }
//     }
// }



// namespace Day17_GenericsLinq
// {
//     public class Threads
//     {
//         public static void Main()
//         {
//             Thread t1 = new Thread(Task1);
//             Thread t2 = new Thread(Task2);
//             t1.Start();
//             t2.Start();
//         }

//         private static void Task2(object? obj)
//         {
//             System.Console.WriteLine("Even numbers:");
//             for(int i = 0; i < 100; i += 2)
//             {
//                 System.Console.Write(i + " ");
//                 Thread.Sleep(100);
//             }
//         }

//         private static void Task1(object? obj)
//         {
//             System.Console.WriteLine("Odd numbers:");
//             for(int i = 1; i < 100; i += 2)
//             {
//                 System.Console.Write(i + " ");
//                 Thread.Sleep(200);
//             }
//         }
//     }
// }



// using System;

// namespace Day17_GenericsLinq
// {
//     public class AsyncAwait
//     {
//         public static async Task AsyncMethod()
//         {
//             Console.WriteLine("Task Started");
//             await Task.Delay(3000);
//             Console.WriteLine("Task Completed After 3 Seconds!");
//         }

//         public static async Task CallMethod()
//         {
//             string? result = await FetchDataAsync("https://jsonplaceholder.typicode.com/todos");
//             Console.WriteLine(result);
//             await AsyncMethod();
//         }

//         private async Task<string?> FetchDataAsync(string v)
//         {
//             using (HttpClient client = new HttpClient())
//             {
//                 var response = await client.GetStringAsync(v);
//                 return response;
//             }
//         }

//         public static async Task Main()
//         {
//             AsyncAwait function = new();
//             await CallMethod();
//         }
//     }
// }


// using System;
// using System.Net.Http;
// using System.Threading.Tasks;

// namespace Day17_GenericsLinq
// {
//     public class AsyncAwait
//     {
//         public static async Task AsyncMethod()
//         {
//             System.Console.WriteLine("Task Started");
//             await Task.Delay(3000);
//             System.Console.WriteLine("Task Completed After 3 Seconds!");
//         }

//         public async Task CallMethod()
//         {
//             string? result = await FetchDataAsync("https://jsonplaceholder.typicode.com/todos");
//             System.Console.WriteLine(result);
//             await AsyncMethod();
//         }

//         private static async Task<string?> FetchDataAsync(string v)
//         {
//             using HttpClient client = new();
//             var response = await client.GetStringAsync(v);
//             return response;
//         }

//         public static void Main()
//         {
//             AsyncAwait function = new();
//             function.CallMethod();
//             Console.ReadLine();

//         }
//     }
// }



