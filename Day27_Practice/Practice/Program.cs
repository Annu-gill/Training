// // Task 1: Call a public method and try to run it using reflection in C#

// using System;
// using System.Reflection;

// class Calculator
// {
//     public void Add(int a, int b)
//     {
//         Console.WriteLine("Sum = " + (a + b));
//     }
// }

// public class Program
// {
//     public static void Main()
//     {
//         // Get type information
//         Type type = typeof(Calculator);

//         // Create object dynamically
//         // object obj = Activator.CreateInstance(type);
//         Calculator obj = new Calculator();


//         // Get public method
//         MethodInfo method = type.GetMethod("Add");
//         method.Invoke(obj, new object[] { 10, 20 });
//     }
// }




// using System.IO.Pipelines;

// public class Test
// {
//     public static int powerGame(int N, int[] A)
//     {
//         int result=-404;
//         long sum=0;
//         for(int i = 0; i < N; i++)
//         {
//             if (sum == 0)
//             {
//                 sum=A[i];
//             }
//             else if (A[i] >= sum)
//             {
//                 sum=0;
//             }
//             else
//             {
//                 sum+=A[i];
//             }
//         }
//         if (sum == 0)
//         {
//             Console.WriteLine("No");
//         }
//         else
//         {
//             Console.WriteLine("Yes, sum is "+sum);
//         }


//         return result;
//     }
//     public static void Main()
//     {
//         int N=Convert.ToInt32(Console.ReadLine());
//         int[] A = new int[N];
//         string[] tokens=Console.ReadLine().Split();
//         int i;

//         for (i = 0; i < N; i++)
//         {
//             A[i]=Convert.ToInt32(tokens[i]);
//         }
//         powerGame(N,A);
//     }
// }


// // using System;
// // using System.ComponentModel;

// // public class Test
// // {
// //     public static string equalSums(string S)
// //     {
// //         string result="-404";
// //         int leftSum=0,rightSum=0, totalSum=0,currentVal;
// //         for(int i = 0; i < S.Length; i++)
// //         {
// //             totalSum += S[i]-'a'+1;
// //         }

// //         for(int i = 0; i < S.Length; i++)
// //         {
// //             currentVal=S[i]-'a'+1;
// //             rightSum=totalSum-leftSum-currentVal;
// //             if (leftSum == rightSum)
// //             {
// //                 return S[i].ToString();
// //             }
// //             leftSum+=currentVal;

// //         }
// //         return result;
// //     }

// //     public static void Main()
// //     {
// //         string S = Console.ReadLine();
// //         Console.WriteLine(equalSums(S));
// //     }
// // }


// // Scenario 1: E-Commerce Inventory System
// // Problem: Design a flexible inventory system that can handle different product categories with varying attributes while maintaining type safety.


// using System;
// using System.Linq;
// using System.Collections.Generic;

// // Base product interface
// public interface IProduct
// {
//     int Id { get; }
//     string Name { get; }
//     decimal Price { get; set; }
//     Category Category { get; }
// }

// public enum Category { Electronics, Clothing, Books, Groceries }

// // 1. Create a generic repository for products
// public class ProductRepository<T> where T : class, IProduct
// {
//     private readonly List<T> _products = [];

//     // TODO: Implement method to add product with validation
//     public void AddProduct(T product)
//     {
//         if (product == null) throw new ArgumentNullException(nameof(product));
//         // Rule: Product ID must be unique
//         if (_products.Any(p => p.Id == product.Id))
//             throw new InvalidOperationException("Product ID must be unique");
//         // Rule: Price must be positive
//         if (product.Price <= 0)
//             throw new ArgumentException("Price must be positive");
//         // Rule: Name cannot be null or empty
//         if (string.IsNullOrEmpty(product.Name))
//             throw new ArgumentException("Name cannot be null or empty");
//         // Add to collection if validation passes
//         _products.Add(product);
//     }

//     // TODO: Create method to find products by predicate
//     public IEnumerable<T> FindProducts(Func<T, bool> predicate)
//     {
//         // Should return filtered products
//         return _products.Where(predicate);
//     }

//     // TODO: Calculate total inventory value
//     public decimal CalculateTotalValue()
//     {
//         // Return sum of all product prices
//         return _products.Sum(p => p.Price);
//     }
// }

// // 2. Specialized electronic product
// public class ElectronicProduct : IProduct
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public decimal Price { get; set; }
//     public Category Category => Category.Electronics;
//     public int WarrantyMonths { get; set; }
//     public string Brand { get; set; }
// }

// // 3. Create a discounted product wrapper
// public class DiscountedProduct<T> where T : IProduct
// {
//     private readonly T _product;
//     private readonly decimal _discountPercentage;

//     public DiscountedProduct(T product, decimal discountPercentage)
//     {
//         // TODO: Initialize with validation
//         // Discount must be between 0 and 100
//         if (product == null) throw new ArgumentNullException(nameof(product));
//         if (discountPercentage < 0 || discountPercentage > 100)
//             throw new ArgumentOutOfRangeException(nameof(discountPercentage), "Discount must be 0-100.");

//         _product = product;
//         _discountPercentage = discountPercentage;
//     }

//     // TODO: Implement calculated price with discount
//     public decimal DiscountedPrice => _product.Price * (1 - _discountPercentage / 100);

//     // TODO: Override ToString to show discount details
//     public override string ToString()
//     {
//         return $"Product Name: {_product.Name}\tOriginal Price: {_product.Price}\tDiscounted Price: {DiscountedPrice}";
//     }
// }

// // 4. Inventory manager with constraints
// public class InventoryManager
// {
//     // TODO: Create method that accepts any IProduct collection
//     public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
//     {
//         if (products == null || !products.Any()) return;
//         Console.WriteLine("Product List:");
//         // a) Print all product names and prices
//         foreach (var p in products)
//             Console.WriteLine($"Item: {p.Name,-12} | Price: ${p.Price,8:F2}");
//         // b) Find the most expensive product
//         var maxProduct = products.MaxBy(p => p.Price);
//         Console.WriteLine(maxProduct!.Name);
//         // c) Group products by category
//         var groups = products.GroupBy(p => p.Category);
//         foreach (var group in groups)
//         {
//             Console.WriteLine($"{group.Key}: {group.Count()}");
//         }
//         // d) Apply 10% discount to Electronics over $500
//         var expensiveItems = products.Where(p => p.Category == Category.Electronics && p.Price > 500);
//         foreach (var e in expensiveItems)
//         {
//             var dp = new DiscountedProduct<T>(e, 10);
//             Console.WriteLine(dp);
//         }
//     }

//     // TODO: Implement bulk price update with delegate
//     public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
//         where T : IProduct
//     {
//         // Apply priceAdjuster to each product
//         try
//         {
//             foreach (var product in products)
//             {
//                 product.Price = priceAdjuster(product);
//             }
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"Error during bulk update: {ex.Message}");
//         }
//         // Handle exceptions gracefully
//     }
// }

// // 5. TEST SCENARIO: Your tasks:
// // a) Implement all TODO methods with proper error handling
// // b) Create a sample inventory with at least 5 products
// // c) Demonstrate:
// //    - Adding products with validation
// //    - Finding products by brand (for electronics)
// //    - Applying discounts
// //    - Calculating total value before/after discount
// //    - Handling a mixed collection of different product types

// public class Program
// {
//     public static void Main()
//     {
//         try
//         {
//             var repo = new ProductRepository<ElectronicProduct>();
//             var manager = new InventoryManager();

//             // 5b) Sample Inventory
//             repo.AddProduct(new ElectronicProduct { Id = 1, Name = "Laptop", Price = 1200m, Brand = "Dell" });
//             repo.AddProduct(new ElectronicProduct { Id = 2, Name = "Phone", Price = 800m, Brand = "Samsung" });
//             repo.AddProduct(new ElectronicProduct { Id = 3, Name = "Webcam", Price = 50m, Brand = "Logitech" });
//             repo.AddProduct(new ElectronicProduct { Id = 4, Name = "Monitor", Price = 450m, Brand = "Dell" });
//             repo.AddProduct(new ElectronicProduct { Id = 5, Name = "Tablet", Price = 600m, Brand = "Apple" });

//             // 5c) Demonstrations
//             Console.WriteLine($"Total Value: ${repo.CalculateTotalValue():F2}");

//             Console.WriteLine("\nSearching for Brand 'Dell':");
//             var dells = repo.FindProducts(p => p.Brand == "Dell");
//             foreach(var d in dells) Console.WriteLine($"- {d.Name}");

//             // Process via Manager
//             var allProducts = repo.FindProducts(p => true).ToList();
//             manager.ProcessProducts(allProducts);

//             // Bulk Update
//             Console.WriteLine("\nAdjusting prices for 5% inflation...");
//             manager.UpdatePrices(allProducts, p => p.Price * 1.05m);
//             Console.WriteLine($"New Total Inventory Value: ${repo.CalculateTotalValue():F2}");
//         }
//         catch (Exception ex)
//         {
//             Console.WriteLine($"FATAL ERROR: {ex.Message}");
//         }
//     }
// }





using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;

public class Employee
{
    public int EmployeeId;
    public string EmployeeDesignation;

    public Employee(int EmployeeId, string EmployeeDesignation)
    {
        this.EmployeeId=EmployeeId;
        this.EmployeeDesignation=EmployeeDesignation;
    }


}

public class EmployeeManagement
{
    private Dictionary<int,Employee> employees=new Dictionary<int, Employee>();
    public void AddEmployee(int EmployeeID, string EmployeeDesignation)
    {
        if (!employees.ContainsKey(EmployeeID))
        {
            employees.Add(EmployeeID,new Employee(EmployeeID,EmployeeDesignation));
        }
    }
    public void UpdateDesignation(int employeeID, string newEmpDesignation)
    {
        if (employees.ContainsKey(employeeID))
        {
            employees[employeeID].EmployeeDesignation=newEmpDesignation;
            Console.WriteLine($"{employeeID}{newEmpDesignation}");

        }
    }
}


public class Program
{
    public static void Main(string[] args)
    {
        EmployeeManagement management = new EmployeeManagement();

        // Adding employees
        management.AddEmployee(101, "Developer");
        management.AddEmployee(102, "Tester");

        // Updating designation
        management.UpdateDesignation(101, "Senior Developer");
        management.UpdateDesignation(102, "QA Engineer");

        Console.ReadLine(); // Keeps console open
    }
}