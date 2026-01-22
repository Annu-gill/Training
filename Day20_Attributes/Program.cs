namespace Day20_Attributes
{
    public class CalculatorMethod
    {
        [Obsolete("Use the Add(int a, int b) method instead")]
        public int OldAdd(int a, int b)
        {
            return a+b;
        }

        public int Add(int a, int b)
        {
            return a+b;
        }
    }

    public class Calculator
    {
        public static void Main()
        {
            CalculatorMethod cm = new();
            int sum1=cm.OldAdd(1,2);
            int sum2=cm.Add(3,4);
            Console.WriteLine(sum1);
            Console.WriteLine(sum2);
        }
    }
}