namespace MyLibrary;

public class Calculator
{
    // Will throw OverflowException when the result overflows an int
    public int Add(int a, int b) => checked(a + b);

    public double Divide(double a, double b)
    {
        if (double.IsNaN(a) || double.IsNaN(b))
            throw new ArgumentException("Inputs must be valid numbers.");
        if (b == 0)
            throw new DivideByZeroException("Cannot divide by zero.");
        if (b < 0)
            throw new ArgumentException("Negative divisor not allowed.", nameof(b));

        return a / b;
    }

    public string GetGreeting(string? name)
    {
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentNullException(nameof(name), "Name must not be null or empty.");
        return $"Hello, {name}!";
    }
}