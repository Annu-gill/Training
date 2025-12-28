using Day06;

class Program
{
    public static void Main(String[] args)
    {
        //Day 06
        Visitor visitor=new Visitor();
        visitor.NonVegEatter();
        visitor.VegEatter();

        IVegEatter vegEatter=new Visitor();
        string vTaste=vegEatter.GetTaste();

        INonVegEatter nonVegEatter=new Visitor();
        string nvTaste=nonVegEatter.GetTaste();
        Console.WriteLine(vTaste);
        Console.WriteLine(nvTaste);
    }
}
