// using System;
// using System.Collections.Generic;
// using System.Linq;
// using System.Text;
// using System.Threading.Tasks;

// namespace Day15_Enum
// {
//     public class CustomException
//     {
//         public static void Main()
//         {
//             try
//             {
//                 int result = Divide(10, 0);
//                 Console.WriteLine("Result: " + result);
//             }
//             catch (AppCustomException ex)
//             {
//                 Console.WriteLine("Error: " + ex.Message);
//             }
//         }

//         private static int Divide(int v1, int v2)
//         {
//             try
//             {
//                 return v1 / v2;
//             }
//             catch 
//             {

//                 throw new AppCustomException();
//             }
           
//         }
//     }
// }