using System;

// make class employee and taxcalculation method which is abstract
abstract class Employee
{
    public int EmpId { get; set; }
    public string Name { get; set; }
    public double Salary { get; set; }

    public abstract double TaxCalculation();
}

// inherit that on US employee
class USEmployee : Employee
{
    public override double TaxCalculation()
    {
        return Salary * 0.20;
    }
}

// inherit that on indian employee
class IndianEmployee : Employee
{
    public override double TaxCalculation()
    {
        return Salary * 0.10;
    }
}



// abstract class means must inherit that class to that class
abstract class Payment
{
    public decimal Amount { get; }

    // protected...only child class can access the value
    protected Payment(decimal amount)
    {
        Amount = amount;
    }

    public void PrintReceipt()
    {
        Console.WriteLine($"Receipt: Amount={Amount}");
    }

    public abstract void Pay(); // must be implemented
}

class UpiPayment : Payment
{
    public string UpiId { get; }

    public UpiPayment(decimal amount, string upiId) : base(amount)
    {
        UpiId = upiId;
    }

    public override void Pay()
    {
        Console.WriteLine($"Paid {Amount} via UPI ({UpiId}).");
    }
}
