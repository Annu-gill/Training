using System;
using System.Collections.Generic;
using System.Linq;

namespace EmployeeManagement
{
    // Employee class
    public class Employee
    {
        public string EmployeeId { get; set; }   // E001, E002...
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
        public DateTime JoiningDate { get; set; }

        public override string ToString()
        {
            return $"{EmployeeId} | {Name} | {Department} | ₹{Salary} | Joined: {JoiningDate:dd-MM-yyyy}";
        }
    }

    // HR Manager class
    public class HRManager
    {
        private List<Employee> employees = new List<Employee>();
        private int idCounter = 1;

        // Add employee with auto-generated ID
        public void AddEmployee(string name, string dept, double salary)
        {
            Employee emp = new Employee
            {
                EmployeeId = "E" + idCounter.ToString("D3"),
                Name = name,
                Department = dept,
                Salary = salary,
                JoiningDate = DateTime.Now
            };

            idCounter++;
            employees.Add(emp);
        }

        // Group employees by department
        public SortedDictionary<string, List<Employee>> GroupEmployeesByDepartment()
        {
            SortedDictionary<string, List<Employee>> result =
                new SortedDictionary<string, List<Employee>>();

            foreach (var emp in employees)
            {
                if (!result.ContainsKey(emp.Department))
                {
                    result[emp.Department] = new List<Employee>();
                }
                result[emp.Department].Add(emp);
            }

            return result;
        }

        // Calculate total salary for a department
        public double CalculateDepartmentSalary(string department)
        {
            return employees
                   .Where(e => e.Department.Equals(department, StringComparison.OrdinalIgnoreCase))
                   .Sum(e => e.Salary);
        }

        // Get employees joined after given date
        public List<Employee> GetEmployeesJoinedAfter(DateTime date)
        {
            return employees
                   .Where(e => e.JoiningDate > date)
                   .ToList();
        }
    }

    // Main Program
    public class Program
    {
        public static void Main()
        {
            HRManager hr = new HRManager();

            // 1. Add employees
            hr.AddEmployee("Amit", "IT", 60000);
            hr.AddEmployee("Neha", "HR", 45000);
            hr.AddEmployee("Rahul", "Sales", 50000);
            hr.AddEmployee("Sneha", "IT", 70000);

            // 2. Display employees grouped by department
            Console.WriteLine("Employees Grouped by Department:\n");
            var groupedEmployees = hr.GroupEmployeesByDepartment();

            foreach (var dept in groupedEmployees)
            {
                Console.WriteLine("Department: " + dept.Key);
                foreach (var emp in dept.Value)
                {
                    Console.WriteLine("  " + emp);
                }
                Console.WriteLine();
            }

            // 3. Calculate total salary per department
            Console.WriteLine("Total Salary in IT Department:");
            Console.WriteLine("₹" + hr.CalculateDepartmentSalary("IT"));

            // 4. Find employees who joined recently
            Console.WriteLine("\nEmployees Joined After Today 12:00 AM:\n");
            var recentEmployees = hr.GetEmployeesJoinedAfter(DateTime.Today);

            foreach (var emp in recentEmployees)
            {
                Console.WriteLine(emp);
            }
        }
    }
}
