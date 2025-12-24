// // make class employee and taxcalculation method which is abstract and inherit that on US employee and indian employee

// using System;

// abstract class Employee
// {
//     public int EmpId{get;set;}
//     public string Name{get;set;}
//     public double Salary{get;set;}
//     public abstract double TaxCalculation();
// }

// class USEmployee : Employee
// {
//     public override double TaxCalculation()
//     {
//         return Salary * 0.20;
//     }
// }

// class IndianEmployee : Employee
// {
//     public override double TaxCalculation()
//     {
//         return Salary *0.10;
//     }
// }

// public class Day05
// {
//     public static void Run()
//     {
//         Console.Write("Enter Employee Type(US/INDIA): ");
//         string type=Console.ReadLine().ToUpper();
//         Employee emp;
//         if (type == "US")
//         {
//             emp=new USEmployee();
//         }
//         else
//         {
//             emp=new IndianEmployee();
//         }
//         Console.Write("Enter Employee ID: ");
//         emp.EmpId = int.Parse(Console.ReadLine());

//         Console.Write("Enter Employee Name: ");
//         emp.Name = Console.ReadLine();

//         Console.Write("Enter Salary: ");
//         emp.Salary = double.Parse(Console.ReadLine());

//         double tax = emp.TaxCalculation();

//         Console.WriteLine("\n--- Employee Details ---");
//         Console.WriteLine("ID: " + emp.EmpId);
//         Console.WriteLine("Name: " + emp.Name);
//         Console.WriteLine("Salary: " + emp.Salary);
//         Console.WriteLine("Tax: " + tax);
//     }
// }



// use of an abstract class for the Payment tasks

// using System;
// // abstract class means must inherit that class to that class
// abstract class Payment
// {
//     public decimal Amount { get; }
//     protected Payment(decimal amount) => Amount = amount; //protected...only child class can access the value

//     public void PrintReceipt()
//     {
//         Console.WriteLine($"Receipt: Amount={Amount}");
//     }

//     public abstract void Pay(); // must be implemented
// }

// class UpiPayment : Payment
// {
//     public string UpiId { get; }
//     public UpiPayment(decimal amount, string upiId) : base(amount) => UpiId = upiId;

//     public override void Pay()
//     {
//         Console.WriteLine($"Paid {Amount} via UPI ({UpiId}).");
//     }
// }

// public class Day05
// {
//     public static void Run()
//     {
//         Payment p = new UpiPayment(499.00m, "ittechgenie@upi");
//         p.Pay();
//         p.PrintReceipt();   
//     }
// }




// // creating commonlib for mathlib and Sciencelib and write code in it and later on add it's reference in Matthlib and Sciencelib

// // in commonlib make abstract login class 

// namespace Commonlib
// {
//     public abstract class LoginAbs
//     {
//         public abstract void Login();
//         public abstract void Logout();

//         public bool LoginProcess()
//         {
//             return true;
//         }
//     }
// }

// // in securitycheck file write it...

// namespace Sciencelib
// {
//     public class Securitycheck
//     {
//         public void checklogin()
//         {
//             LoginAbs loginAbs=new LoginAbs();
//             loginAbs.
//         }
//     }
// }

// namespace Sciencelib
// {
//     public class SciLogin : LoginAbs
//     {
//         public override void Login(string)
//         {
//             throw new NotImplementedException();s
//         }()
//     }
// }

// abstract class means must inherit that class to that class

