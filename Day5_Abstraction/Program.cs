using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("1. Employee Tax Calculation");
        Console.WriteLine("2. Payment Using Abstract Class");
        Console.Write("\nEnter choice: ");

        int choice = int.Parse(Console.ReadLine());

        if (choice == 1)
        {
            // make class employee and taxcalculation method which is abstract
            // and inherit that on US employee and indian employee

            Console.Write("Enter Employee Type(US/INDIA): ");
            string type = Console.ReadLine().ToUpper();

            Employee emp;

            if (type == "US")
            {
                emp = new USEmployee();
            }
            else
            {
                emp = new IndianEmployee();
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
        else if (choice == 2)
        {
            // use of an abstract class for the Payment tasks
            Payment p = new UpiPayment(499.00m, "ittechgenie@upi");
            p.Pay();
            p.PrintReceipt();
        }
        else
        {
            Console.WriteLine("Invalid choice");
        }
    }
}
