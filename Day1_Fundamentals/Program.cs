using System;

class Program
{
    static void Main(string[] args)
    {
        // Call ONE program at a time

        EnterName.Execute();
        Eligibility.Execute();
        AdultCheck.Execute();
        FeetToCentimeter.Execute();
    }
}
