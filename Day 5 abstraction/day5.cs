// make class employee and taxcalculation method which is abstract and inherit that on US employee and indian employee

abstract class Employee
{
    public int EmpId{get;set;}
    public string Name{get;set;}
    public double Salary{get;set;}
    public abstract double TaxCalculation();
}

class USEmployee : Employee
{
    public override double TaxCalculation()
    {
        return Salary * 0.20;
    }
}

class IndianEmployee : Employee
{
    public override double TaxCalculation()
    {
        return Salary *0.10;
    }
}

public class Day05
{
    public static void Run()
    {
        Console.Write("Enter Employee Type(US/INDIA): ");
        string type=Console.ReadLine().ToUpper();
        Employee emp;
        if (type == "US")
        {
            emp=new USEmployee();
        }
        else
        {
            emp=new IndianEmployee();
        }
        Console.Write("Enter Employee ID: ");
        emp.EmpId = int.Parse(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        emp.Name = Console.ReadLine();

        Console.Write("Enter Salary: ");
        emp.Salary = double.Parse(Console.ReadLine());

        double tax = emp.TaxCalculation();

        Console.WriteLine("\n--- Employee Details ---");
        Console.WriteLine("ID: " + emp.EmpId);
        Console.WriteLine("Name: " + emp.Name);
        Console.WriteLine("Salary: " + emp.Salary);
        Console.WriteLine("Tax: " + tax);
    }
}