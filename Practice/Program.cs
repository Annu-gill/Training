using System;

namespace Practice
{
    public class Employee
    {
        public int Id{get; set;}
        public string Name{get;set;}
        public int Salary{get;set;}
        public void Display()
        {
            Console.WriteLine($"Id: "+Id+"Name: "+Name+"Salary: ");

        }
        
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Employee emp=new Employee(1, "Annu",100000);
        }
    }
}