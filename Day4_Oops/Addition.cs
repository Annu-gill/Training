using System;

// Addition of 2 numbers with constructor
// use get, set in this one

class Addition
{
    public int A { private set; get; }
    public int B { private set; get; }

    public Addition(int x, int y)
    {
        A = x;
        B = y;
    }

    public void Add()
    {
        Console.WriteLine("a+b = " + (A + B));
    }
}
