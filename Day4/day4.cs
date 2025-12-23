

// using System;

// // OOPS Concept -> Overloading of Constructor && Changing Namespace

// class Visitor
// {
//     public int Id{set; get;}
//     public string Name{get; set;}
//     public string Requirement{get; set;}
//     public string LogHistory{get; set;}

//     public Visitor()
//     {
//         LogHistory="";
//         LogHistory+=$"Object created at {DateTime.Now} {Environment.NewLine}";
//     }

//     public Visitor(int id) : this()
//     {
//         // this.Id = id;
//         LogHistory+=$"Id created at {DateTime.Now} {Environment.NewLine}";
//     }

//     public Visitor(int id , string name):this(id)
//     {
//         // this.Id = id;

//         if (name.ToLower().Contains("idiot"))
//         {
//             throw new Exception ("Invalid name...");
//         }
//         LogHistory+=$"Name created at {DateTime.Now} {Environment.NewLine}";
//         this.Name = name;
//     }

//     public Visitor(int id , string name , string requirement):this(id, name)
//     {
//         // this.Id = id;
//         // this.Name = name;
//         this.Requirement = requirement;
//         LogHistory+=$"Reguirement created at {DateTime.Now} {Environment.NewLine}";
        
//     }
// }

// public class MainConstructor
// {
//     public static void Main(String[] args)
//     {
//         Visitor dd=new Visitor();
//         try
//         {
//             Visitor visitor=new Visitor(10, "ravi ");
//             Console.WriteLine(visitor.LogHistory);
//         }
//         catch(Exception ex)
//         {
//             Console.WriteLine(ex.Message);
//         }
//     }
// }


// create fields both private and public using get and set validate the fields for name, id, and all and write code in c#



// // Addition of 2 numbers with constructor

// // use get, set in this one
// using System;
// class Addition
// {
//     int a, b;
//     public Addition(int x, int y)
//     {
//         a=x;
//         b=y;
//     }
//     public void Add()
//     {
//         int sum=a+b;;
//         Console.WriteLine("a+b = "+sum);
//     }
// }

// class Program()
// {
//     public static void Main(String[] args)
//         {
//             Addition obj = new Addition(10, 20);
//             // Calling method
//             obj.Add();
//         }
// }

// // only set property....hw




// using System;

// class Employee
// {
//     // Private fields
//     private int id;
//     private string name;
//     private double salary;

//     private string Errors="";

//     // Public property for Id
//     public int Id
//     {
//         get { return id; }
//         set
//         {
//             if (value > 0)
//                 id = value;
//             else
//             {
//                 Errors+= "Invalid Id! Id must be greater than 0."+ Environment.NewLine;
//                 // Console.WriteLine("Invalid Id! Id must be greater than 0.");
//             }
//         }
//     }

//     // Public property for Name
//     public string Name
//     {
//         get { return name; }
//         set
//         {
//             if (!string.IsNullOrWhiteSpace(value))
//                 name = value;
//             else
//                 Errors+="Invalid Name! Name cannot be empty."+Environment.NewLine;
//                 // Console.WriteLine("Invalid Name! Name cannot be empty.");
//         }
//     }

//     // Public property for Salary
//     public double Salary
//     {
//         get { return salary; }
//         set
//         {
//             if (value >= 0)
//                 salary = value;
//             else
//                 Errors+="Invalid Salary! Salary cannot be negative."+Environment.NewLine;
//                 // Console.WriteLine("Invalid Salary! Salary cannot be negative.");
//         }
//     }

//     // Display method
//     public void Display()
//     {
//         Console.WriteLine("\n--- Employee Details ---");
//         Console.WriteLine("Employee Id    : " + Id);
//         Console.WriteLine("Employee Name  : " + Name);
//         Console.WriteLine("Employee Salary: " + Salary);
//     }

//     public string GetErrors()
//     {
//         return Errors;
//     }
// }

// class Program
// {
//     static void Main(string[] args)
//     {
//         Employee emp = new Employee();

//         // Taking input from user
//         Console.Write("Enter Employee Id: ");
//         emp.Id = Convert.ToInt32(Console.ReadLine());

//         Console.Write("Enter Employee Name: ");
//         emp.Name = Console.ReadLine();

//         Console.Write("Enter Employee Salary: ");
//         emp.Salary = Convert.ToDouble(Console.ReadLine());

//         if (!string.IsNullOrEmpty(emp.GetErrors()))
//         {
//             Console.WriteLine("\n--- Validation Errors ---");
//             Console.WriteLine(emp.GetErrors());
//         }
//         else
//         {
//             emp.Display();
//         }
//     }
// }



// using System;

// public class Account
// {
//     public string Name { get; set; }
//     public int AccountId { get; set; }

//     public string GetAccountDetails()
//     {
//         return $"I am Base account . My Id is {AccountId}";
//     }
// }
// public class SalesAccount : Account 
// {
//     public string GetSalesAccountDetails()
//     {
//         string info = string.Empty;
//         info += base.GetAccountDetails();
//         info += "I am from Sales Derived class ";
//         return info;
//     }
//     public string SalesInfo { get; set; }
// }

// public class PurchaseAccount : Account
// {
//     public string PurchaseInfo { get; set; }
// }

// public class CallAccount
// {
//     public static void Main(string[] args)
//     {
//         Account account = new Account() { AccountId = 1, Name = "Account1" };
//         string result = account.GetAccountDetails();
//         Console.WriteLine(result);

//         SalesAccount salesAccount = new SalesAccount() { AccountId = 1, Name = "Balu", SalesInfo = " " };
//         var result1=salesAccount.GetSalesAccountDetails();
//         Console.WriteLine(result1);
//     }
// }


// using System;
// public class Father
// {
//     public virtual string InterestOn() // virtual allows child to override
//     {
//         return "I like to play Cricket";
//     }
// }
// public class Son : Father
// {
//     public override string InterestOn()
//     {
//         return "Mobile Games";
//     }
// }
// class Program
// {
//     static void Main(string[] args)
//     {
//         Father f = new Father();
//         Console.WriteLine(f.InterestOn());
        
//         Father s = new Son();   // Parent reference, child object
//         Console.WriteLine(s.InterestOn());
//     }
// }
