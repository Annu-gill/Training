

namespace Day6
{
    public interface  IPrint
    {
        public void Print();
    }

    public class Printer : IPrint
    {
        public void Print()
        {
            System.Console.WriteLine("Hello");
        }
    }
    class Program
    {
        public static void Main()
        {
            IPrint obj=new Printer();
            obj.Print();
        }
    }
}



