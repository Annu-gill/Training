// using System;
// namespace Day12_StructToXML
// {
//     public delegate int DelegateAddFunctionName(int a, int b);

//     public class ExampleDelegate
//     {
//         public int a;
//         public int b;

//         public void DelegateEx1()
//         {
//             DelegateAddFunctionName delegateVariable = new DelegateAddFunctionName(AddMethod3);
//             Console.WriteLine(delegateVariable(1, 2));
//         }

//         private int AddMethod3(int a, int b)
//         {
//             return a + b + 40;
//         }


//         private int AddMethod2(int a, int b)
//         {
//             return a + b + 10;
//         }
//     }

//     public class ExampleOfDelegate
//     {
//         public static void Main(string[] args)
//         {
//             ExampleDelegate exampleOfDelegate = new ExampleDelegate();
//             exampleOfDelegate.DelegateEx1();
//         }
//     }
// }


// // create property of delegate in another class

using System;

namespace Day12_StructToXML
{
    // Delegate created in another class
    public class DelegateDefinition
    {
        public delegate int DelegateAddFunctionName(int a, int b);
    }
    public class DelegateHolder
    {
        // Delegate property
        public DelegateDefinition.DelegateAddFunctionName AddOperation { get; set; }
    }
    public class MathOperations
    {
        public int AddNormal(int a, int b)
        {
            return a + b;
        }

        public int AddWithExtra(int a, int b)
        {
            return a + b + 40;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            MathOperations math = new MathOperations();
            DelegateHolder holder = new DelegateHolder();

            // Assign method to delegate property
            holder.AddOperation = math.AddWithExtra;

            // Invoke delegate
            int result = holder.AddOperation(5, 10);

            Console.WriteLine("Result: " + result);
        }
    }
}



