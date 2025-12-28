using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Constructor Overloading Demo ===");
        VisitorDemo();

        Console.WriteLine("\n=== Addition Using Constructor ===");
        AdditionDemo();

        Console.WriteLine("\n=== Property Validation Demo ===");
        EmployeeDemo();

        Console.WriteLine("\n=== Base and Derived Class Demo ===");
        AccountDemo();

        Console.WriteLine("\n=== Method Overriding Demo ===");
        InheritanceDemo();
    }

    static void VisitorDemo()
    {
        try
        {
            Visitor visitor = new Visitor(10, "Ravi", "Meeting");
            Console.WriteLine(visitor.LogHistory);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    static void AdditionDemo()
    {
        Addition obj = new Addition(10, 20);
        obj.Add();
    }

    static void EmployeeDemo()
    {
        Employee emp = new Employee();

        Console.Write("Enter Employee Id: ");
        emp.Id = Convert.ToInt32(Console.ReadLine());

        Console.Write("Enter Employee Name: ");
        emp.Name = Console.ReadLine();

        Console.Write("Enter Employee Salary: ");
        emp.Salary = Convert.ToDouble(Console.ReadLine());

        if (!string.IsNullOrEmpty(emp.GetErrors()))
            Console.WriteLine(emp.GetErrors());
        else
            emp.Display();
    }

    static void AccountDemo()
    {
        Account account = new Account { AccountId = 1, Name = "Account1" };
        Console.WriteLine(account.GetAccountDetails());

        SalesAccount sales = new SalesAccount { AccountId = 2, Name = "Balu" };
        Console.WriteLine(sales.GetSalesAccountDetails());
    }

    static void InheritanceDemo()
    {
        Father f = new Father();
        Console.WriteLine(f.InterestOn());

        Father s = new Son();
        Console.WriteLine(s.InterestOn());
    }
}
