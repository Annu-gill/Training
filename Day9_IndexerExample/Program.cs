using System;
namespace Day9_IndexerExample
{
    class MyObj
    {
        private string[] values = new string[3];
        public string this[int index]
        {
            get
            {
                return values[index];
            }
            set
            {
                values[index] = value;
            }
        }
    }

    class Indexers
    {
        public static void Main()
        {
            MyObj obj = new();
            obj[0] = "C#";
            obj[1] = "C++";
            obj[2] = "C#";

            System.Console.WriteLine("First index: " + obj[0]);
            System.Console.WriteLine("Second index: " + obj[1]);
            System.Console.WriteLine("Second index: " + obj[2]);
        }
    }
}
