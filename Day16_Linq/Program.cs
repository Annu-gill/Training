// namespace Day16_Linq
// {
//     public class LinqExample
//     {
//         public LinqStudent()
//         {

//         }

//         public static void LinqExample2()
//         {
//             var procCollecion=from p in System.Diagnostics.Process.GetProcesses()
//                 select p;
//             foreach(var proc in procCollecion)
//             {
//                 var manipulateCollection=new MyProcess() { Name=proc.name};
//             }
//         }

//         public LinqExample()
//         {
//             string[] names = ["Annu", "B", "C"];
//             foreach (var v in names)
//             {
//                 if (v == "B") 
//                 Console.WriteLine("B Exists");
//             }

//             var findName = from n in names 
//                 // where n == "B" 
//                 orderby n ascending
//                 // select IsPalindrome(n);
//                 // select n.ToUpper();
//                 select new LinqStudent() { Name = n};

//             // if (findName != null) Console.WriteLine("found");

//             foreach (var item in findName)
//             {
//                 Console.WriteLine(item.Name);
//             }
//             Console.ReadLine();
//         }
//         public static string IsPalindrome(string name)
//         {
//             // if (name.Reverse() == name)
//             // {
//             //     return name +" is Palindrome";
//             // }
//             // return name+" is not a palindrome";

//             string reversed = new string(name.Reverse().ToArray());

//             if (string.Equals(name, reversed, StringComparison.OrdinalIgnoreCase))
//             {
//                 return name + " is a Palindrome";
//             }

//             return name + " is not a Palindrome";
//         }
//     }

//     public class Program
//     {
//         public static void Main()
//         {
//             LinqExample lq = new();
//         }
//     }
// }




// namespace Day16_Linq
// {
//     public class LinqExample
//     {
//         public LinqExample()
//         {
//             string[] names = ["AAA", "B", "C", "Madam", "noon"];

//             // foreach (var v in names)
//             // {
//             //     if (v == "B")
//             //         System.Console.WriteLine("Exists");
//             // }

//             // var findNames = from n in names
//             //                 orderby n descending
//             //                 select IsPalindrome(n);


//             var findNames = from n in names
//                             orderby n descending
//                             select new LinqStudent(){Name = n};

//             foreach (var v in findNames)
//             {
//                 System.Console.WriteLine(v.Name);
//             }
//         }
//         public static string IsPalindrome(string name)
//         {
//             string reversedName = new(name.Reverse().ToArray());

//             if (reversedName.ToLower() == name.ToLower())
//             {
//                 return "It is Palindrome.";
//             }
//             return "It is not a Palindrome.";
//         }
//     }

//     public class LinqStudent
//     {
//         public LinqStudent()
//         {
//         }

//         public object? Name { get; set; }
//     }

//     public class Program 
//     {
//         public static void Main()
//         {
//             LinqExample lq = new();
//             LinqExample2();
//             LinqExample3();
//         }

//         public static void LinqExample2()
//         {
//             var proCollection = from p in System.Diagnostics.Process.GetProcesses() 
//                 select new MyProcess(){ Name = p.ProcessName, Id = p.Id};
//             foreach(var v in proCollection)
//             {
//                 System.Console.WriteLine($"Process Name: {v.Name}       Id: {v.Id}");
//             }
//         }

//         public static void LinqExample3()   //this one is anonymous... created by microsoft, doesn't have any name, ms will create class on it's own and will be use in the scope
//         {
//             var proCollection = from p in System.Diagnostics.Process.GetProcesses() 
//                 select new { Name = p.ProcessName, Id = p.Id};
//             foreach(var v in proCollection)
//             {
//                 System.Console.WriteLine($"Process Name: {v.Name}       Id: {v.Id}");
//             }
//         }
//     }

//     internal class MyProcess
//     {
//         public MyProcess()
//         {
//         }

//         public object? Name { get; set; }
//         public int Id { get; internal set; }
//     }
// }


// view model: created to display model
// model: class we create



// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace Day16_Linq
// {
//     public class Student(string name, double marks1, double marks2)
//     {
//         public string Name { get; set; } = name;
//         public double Marks1 { get; set; } = marks1;
//         public double Marks2 { get; set; } = marks2;
//     }

//     public class LinqClass
//     {
//         public static void DisplayMaxAverage(List<Student> students)
//         {
//             var maxAverage =
//                 (from s in students
//                  select (s.Marks1 + s.Marks2) / 2)
//                 .Max();

//             Console.WriteLine($"Max Average: {maxAverage}");
//         }

//         public static void Main()
//         {
//             var students = new List<Student>
//             {
//                 new("Alice", 80, 90),
//                 new("Bob", 85, 95),
//                 new("Charlie", 70, 75)
//             };

//             DisplayMaxAverage(students);
//         }
//     }
// }


// using generic collection with Linq

// using System;
// using System.Collections.Generic;
// using System.Linq;

// namespace Day16_Linq
// {
//     // Student class using primary constructor
//     public class Student(string name, double marks1, double marks2)
//     {
//         public string Name { get; set; } = name;
//         public double Marks1 { get; set; } = marks1;
//         public double Marks2 { get; set; } = marks2;
//     }

//     public class LinqClass
//     {
//         // Method accepts a GENERIC collection
//         public static void DisplayMaxAverage(IEnumerable<Student> students)
//         {
//             var maxAverage =
//                 (from s in students
//                  select (s.Marks1 + s.Marks2) / 2)
//                 .Max();

//             Console.WriteLine($"Max Average Marks: {maxAverage}");
//         }

//         public static void Main()
//         {
//             // Generic collection (List<T> implements IEnumerable<T>)
//             IEnumerable<Student> students = new List<Student>
//             {
//                 new Student("Alice", 80, 90),
//                 new Student("Bob", 85, 95),
//                 new Student("Charlie", 70, 75)
//             };

//             DisplayMaxAverage(students);
//         }
//     }
// }



using System;
using System.Collections.Generic; // For List<T> and Dictionary<TKey,TValue>
using System.Linq;                // For LINQ methods like Where, Select, GroupBy, Join

namespace Day16_Linq
{
    /// <summary>
    /// LearnLinq demonstrates BOTH:
    /// 1) Generics (type-safe reusable code)
    /// 2) LINQ (querying/filtering/grouping/joining collections)
    ///
    /// You can run: LearnLinq.RunDemo();
    /// </summary>
    public class LearnLinq
    {
        // -----------------------------
        // 1) MODEL CLASSES (our data)
        // -----------------------------

        /// <summary>
        /// A simple Employee model (like a table row).
        /// In real apps, this could come from a database (EF Core) or an API.
        /// </summary>
        private class Employee
        {
            public int EmpId { get; set; }              // Unique employee id (primary key idea)
            public string Name { get; set; } = "";      // Employee name
            public int DeptId { get; set; }             // Which department employee belongs to (foreign key idea)
            public decimal Salary { get; set; }         // Salary as decimal (better for money)
            public bool IsActive { get; set; }          // Active / inactive status
        }

        /// <summary>
        /// A Department model (another list we will JOIN with employees).
        /// </summary>
        private class Department
        {
            public int DeptId { get; set; }             // Department id
            public string DeptName { get; set; } = "";  // Department name
            public string City { get; set; } = "";      // Location/city
        }

        // ---------------------------------------------------
        // 2) GENERIC UTILITIES (write once, reuse everywhere)
        // ---------------------------------------------------

        /// <summary>
        /// Generic method: Prints any list of items (Employee, Department, int, string...)
        /// Because it uses T, it becomes reusable for any type.
        /// </summary>
        private static void PrintAll<T>(IEnumerable<T> items, string title)
        {
            Console.WriteLine();
            Console.WriteLine("====================");
            Console.WriteLine(title);
            Console.WriteLine("====================");

            // We can foreach any IEnumerable<T>
            // This works because IEnumerable<T> means "I can be iterated".
            foreach (T item in items)
            {
                // item.ToString() will run.
                // For custom objects, ToString() gives class name unless you override it.
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Generic method + constraint:
        /// where T : class  → T must be a reference type (like Employee, Department, string)
        /// This is useful when you want to allow "null" and handle it safely.
        /// </summary>
        private static T? FindFirstOrNull<T>(IEnumerable<T> items, Func<T, bool> predicate) where T : class
        {
            // FirstOrDefault returns null if nothing matches (for reference types).
            // Predicate is a function that returns true/false (used for filtering).
            return items.FirstOrDefault(predicate);
        }

        // ----------------------------------------
        // 3) MAIN DEMO METHOD (call from Program)
        // ----------------------------------------
        public static void RunDemo()
        {
            // -----------------------------
            // A) Create sample data lists
            // -----------------------------

            // Generics: List<Employee> can store ONLY Employee objects.
            List<Employee> employees = new List<Employee>
            {
                new Employee { EmpId = 1001, Name = "Arun",   DeptId = 1, Salary = 48000, IsActive = true  },
                new Employee { EmpId = 1002, Name = "Divya",  DeptId = 2, Salary = 62000, IsActive = true  },
                new Employee { EmpId = 1003, Name = "Mubeen", DeptId = 1, Salary = 55000, IsActive = true  },
                new Employee { EmpId = 1004, Name = "Ravi",   DeptId = 3, Salary = 0,     IsActive = false }, // salary missing/0
                new Employee { EmpId = 1005, Name = "Anita",  DeptId = 2, Salary = 38000, IsActive = true  },
                new Employee { EmpId = 1006, Name = "Kumar",  DeptId = 1, Salary = 32000, IsActive = true  },
            };

            // Another generic list: List<Department>
            List<Department> departments = new List<Department>
            {
                new Department { DeptId = 1, DeptName = "IT",      City = "Chennai"   },
                new Department { DeptId = 2, DeptName = "HR",      City = "Bengaluru" },
                new Department { DeptId = 3, DeptName = "Finance", City = "Mumbai"    }
            };

            // ---------------------------------------------
            // B) LINQ 1: Filter (Where) + Sort (OrderBy)
            // ---------------------------------------------

            // Business idea:
            // "Get active employees whose salary is greater than 50,000 and sort by salary descending."
            var highEarners = employees
                .Where(e => e.IsActive)                    // keep only active employees
                .Where(e => e.Salary > 50000)               // keep salary > 50,000
                .OrderByDescending(e => e.Salary)           // sort highest salary first
                .Select(e => new                           // projection: create a NEW object with only needed fields
                {
                    e.EmpId,
                    e.Name,
                    e.Salary
                })
                .ToList();                                  // execute NOW and store results in memory

            Console.WriteLine("1) High Earners (Active + Salary > 50,000)");
            foreach (var e in highEarners)
            {
                Console.WriteLine($"EmpId={e.EmpId}, Name={e.Name}, Salary={e.Salary}");
            }

            // ---------------------------------------------
            // C) LINQ 2: GroupBy (group employees by DeptId)
            // ---------------------------------------------

            // Business idea:
            // "For each department, show how many employees and average salary."
            var deptSummary = employees
                .Where(e => e.IsActive)                         // consider only active employees for summary
                .GroupBy(e => e.DeptId)                          // create groups by DeptId
                .Select(g => new
                {
                    DeptId = g.Key,                               // Key is DeptId
                    EmployeeCount = g.Count(),                    // number of employees in that group
                    AvgSalary = g.Average(x => x.Salary)          // average salary in that group
                })
                .OrderByDescending(x => x.AvgSalary)              // show highest average first
                .ToList();

            Console.WriteLine();
            Console.WriteLine("2) Department Summary (Active employees)");
            foreach (var d in deptSummary)
            {
                Console.WriteLine($"DeptId={d.DeptId}, Count={d.EmployeeCount}, AvgSalary={d.AvgSalary:0.00}");
            }

            // ---------------------------------------------
            // D) LINQ 3: JOIN (employees + departments)
            // ---------------------------------------------

            // Business idea:
            // "Show each employee with Department name and City"
            var empWithDept = employees
                .Join(
                    departments,                 // the second collection to join with
                    e => e.DeptId,               // key from employees
                    d => d.DeptId,               // key from departments
                    (e, d) => new                // result selector: what to produce after match
                    {
                        e.EmpId,
                        e.Name,
                        Department = d.DeptName,
                        Location = d.City,
                        e.Salary,
                        e.IsActive
                    })
                .OrderBy(x => x.Department)       // sort by department name
                .ThenByDescending(x => x.Salary)  // within same department, highest salary first
                .ToList();

            Console.WriteLine();
            Console.WriteLine("3) Employees with Department (JOIN)");
            foreach (var row in empWithDept)
            {
                Console.WriteLine($"{row.Name} ({row.EmpId}) - {row.Department} - {row.Location} - Salary={row.Salary} - Active={row.IsActive}");
            }

            // ---------------------------------------------------------
            // E) Generics + LINQ together: FindFirstOrNull<Employee>
            // ---------------------------------------------------------

            // Business idea:
            // "Find the first active HR employee."
            Employee? firstActiveHrEmployee = FindFirstOrNull(employees, e => e.IsActive && e.DeptId == 2);

            Console.WriteLine();
            Console.WriteLine("4) First Active HR Employee (Generic method + LINQ)");

            if (firstActiveHrEmployee == null)
            {
                Console.WriteLine("No active HR employee found.");
            }
            else
            {
                Console.WriteLine($"Found: {firstActiveHrEmployee.Name} (EmpId={firstActiveHrEmployee.EmpId})");
            }

            // ---------------------------------------------------------
            // F) Bonus: Dictionary<TKey,TValue> using LINQ counts
            // ---------------------------------------------------------

            // Business idea:
            // "Count employees by department name."
            // Step 1: join employees with departments
            // Step 2: group by department name
            // Step 3: convert to Dictionary
            Dictionary<string, int> countsByDeptName = employees
                .Join(departments, e => e.DeptId, d => d.DeptId, (e, d) => new { e, d })
                .GroupBy(x => x.d.DeptName)
                .ToDictionary(g => g.Key, g => g.Count());

            Console.WriteLine();
            Console.WriteLine("5) Employee Count by Department (Dictionary + LINQ)");
            foreach (var kv in countsByDeptName)
            {
                Console.WriteLine($"{kv.Key} => {kv.Value}");
            }

            // ---------------------------------------------
            // G) Reuse the Generic PrintAll<T> method
            // ---------------------------------------------

            // PrintAll works with any type.
            // Here we print department objects by projecting to strings.
            PrintAll(
                departments.Select(d => $"DeptId={d.DeptId}, Name={d.DeptName}, City={d.City}"),
                "6) Departments (Printed using Generic PrintAll<T>)"
            );
        }
    }
    class Program
    {
        static void Main()
        {
            LearnLinq.RunDemo();
        }
    }
}


/*
-----------------------------------------
HOW TO RUN (Console App)
-----------------------------------------
1) Create a new C# Console App
2) Add this file (or paste code)
3) In Program.cs, call:

-----------------------------------------
*/

// using LearningCSharp;



