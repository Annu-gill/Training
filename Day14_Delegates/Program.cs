
// // single casting delegates

// using System;

// namespace Day14_Delegates
// {
//     public delegate string PrintMessage(string message);
//     public class PrintingCompany
//     {
//         public PrintMessage CustomerChoicePrintMessage {get;set;}
//         public void Print(string message)
//         {
//             string messageToPrint=CustomerChoicePrintMessage(message);
//             Console.WriteLine(messageToPrint);
//         }    
//     }
//     public class Program
//     {
//         public static void Main()
//         {
//             PrintingCompany printingCompany=new();
//             printingCompany.CustomerChoicePrintMessage+=new PrintMessage(Method1);
//             printingCompany.CustomerChoicePrintMessage=new PrintMessage(HappyNewYear);
//             printingCompany.Print("Annu");
//         }
//         private static string Method1(string message)
//         {
//             return "Hello "+message;
//         }
//         private static string HappyNewYear(string message)
//         {
//             return "Happy New year "+message;
//         }
//     }
    
// }



// multi casting delegates 

using System;

namespace Day14_Delegates
{
    public delegate string MyDelegate(string message);

    public class PrintingCompany
    {
        public MyDelegate? MultiCastPrintMessage { get; set; }

        public void Print(string message)
        {
            if (MultiCastPrintMessage == null)
                return;

            foreach (MyDelegate handler in MultiCastPrintMessage.GetInvocationList())
            {
                string result = handler(message);
                Console.WriteLine(result);
            }
        }
    }

    public class MultiCastDelegate
    {
        public static void Main()
        {
            MyDelegate d = Method1;
            d += Method2;
            d += Method3;

            // This calls all three methods
            d("Hello");
        }

        private static string Method1(string message)
        {
            Console.WriteLine("A: " + message);
            return "A: " + message;
        }

        private static string Method2(string message)
        {
            Console.WriteLine("B: " + message);
            return "B: " + message;
        }

        private static string Method3(string message)
        {
            Console.WriteLine("C: " + message);
            return "C: " + message;
        }
    }
}

