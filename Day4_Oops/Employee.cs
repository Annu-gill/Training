using System;

// only set property....hw

class Employee
{
    private int id;
    private string name;
    private double salary;
    private string Errors = "";

    public int Id
    {
        set
        {
            if (value > 0)
                id = value;
            else
                Errors += "Invalid Id\n";
        }
        get => id;
    }

    public string Name
    {
        set
        {
            if (!string.IsNullOrWhiteSpace(value))
                name = value;
            else
                Errors += "Invalid Name\n";
        }
        get => name;
    }

    public double Salary
    {
        set
        {
            if (value >= 0)
                salary = value;
            else
                Errors += "Invalid Salary\n";
        }
        get => salary;
    }

    public void Display()
    {
        Console.WriteLine($"Id:{id} Name:{name} Salary:{salary}");
    }

    public string GetErrors() => Errors;
}
