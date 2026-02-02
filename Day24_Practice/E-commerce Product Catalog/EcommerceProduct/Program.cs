using System;
using System.Collections.Generic;
using System.Linq;

namespace EcommerceProductCatalog
{
    // Product class
    public class Product
    {
        public string ProductCode { get; set; }   // P001, P002...
        public string ProductName { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int StockQuantity { get; set; }

        public override string ToString()
        {
            return $"{ProductCode} | {ProductName} | {Category} | ₹{Price} | Stock: {StockQuantity}";
        }
    }

    // Inventory Manager
    public class InventoryManager
    {
        private List<Product> products = new List<Product>();
        private int codeCounter = 1;

        // Add product with auto-generated product code
        public void AddProduct(string name, string category, double price, int stock)
        {
            Product product = new Product
            {
                ProductCode = "P" + codeCounter.ToString("D3"),
                ProductName = name,
                Category = category,
                Price = price,
                StockQuantity = stock
            };

            codeCounter++;
            products.Add(product);
        }

        // Group products by category
        public SortedDictionary<string, List<Product>> GroupProductsByCategory()
        {
            SortedDictionary<string, List<Product>> result =
                new SortedDictionary<string, List<Product>>();

            foreach (var product in products)
            {
                if (!result.ContainsKey(product.Category))
                {
                    result[product.Category] = new List<Product>();
                }
                result[product.Category].Add(product);
            }

            return result;
        }

        // Update stock
        public bool UpdateStock(string productCode, int quantity)
        {
            var product = products.FirstOrDefault(p => p.ProductCode == productCode);

            if (product == null || product.StockQuantity < quantity)
                return false;

            product.StockQuantity -= quantity;
            return true;
        }

        // Products below price
        public List<Product> GetProductsBelowPrice(double maxPrice)
        {
            return products.Where(p => p.Price <= maxPrice).ToList();
        }

        // Category stock summary
        public Dictionary<string, int> GetCategoryStockSummary()
        {
            Dictionary<string, int> summary = new Dictionary<string, int>();

            foreach (var product in products)
            {
                if (!summary.ContainsKey(product.Category))
                {
                    summary[product.Category] = 0;
                }
                summary[product.Category] += product.StockQuantity;
            }

            return summary;
        }
    }

    // Main Program
    class Program
    {
        static void Main()
        {
            InventoryManager manager = new InventoryManager();
            int choice;

            do
            {
                Console.WriteLine("\nE-Commerce Product Catalog");
                Console.WriteLine("1. Add Product");
                Console.WriteLine("2. Display Products by Category");
                Console.WriteLine("3. Update Stock");
                Console.WriteLine("4. Find Products Under Budget");
                Console.WriteLine("5. Show Category Stock Summary");
                Console.WriteLine("0. Exit");
                Console.Write("Enter choice: ");

                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Product Name: ");
                        string name = Console.ReadLine();

                        Console.Write("Category (Electronics/Clothing/Books): ");
                        string category = Console.ReadLine();

                        Console.Write("Price: ");
                        double price = double.Parse(Console.ReadLine());

                        Console.Write("Stock Quantity: ");
                        int stock = int.Parse(Console.ReadLine());

                        manager.AddProduct(name, category, price, stock);
                        Console.WriteLine("Product added successfully.");
                        break;

                    case 2:
                        var grouped = manager.GroupProductsByCategory();
                        Console.WriteLine("\nProducts by Category:");
                        foreach (var group in grouped)
                        {
                            Console.WriteLine(group.Key + ":");
                            foreach (var product in group.Value)
                            {
                                Console.WriteLine("  " + product);
                            }
                        }
                        break;

                    case 3:
                        Console.Write("Enter Product Code: ");
                        string code = Console.ReadLine();

                        Console.Write("Quantity Sold: ");
                        int qty = int.Parse(Console.ReadLine());

                        if (manager.UpdateStock(code, qty))
                            Console.WriteLine("Stock updated.");
                        else
                            Console.WriteLine("Invalid code or insufficient stock.");
                        break;

                    case 4:
                        Console.Write("Enter maximum price: ");
                        double maxPrice = double.Parse(Console.ReadLine());

                        var cheapProducts = manager.GetProductsBelowPrice(maxPrice);
                        Console.WriteLine("\nProducts within budget:");
                        foreach (var p in cheapProducts)
                        {
                            Console.WriteLine(p);
                        }
                        break;

                    case 5:
                        var summary = manager.GetCategoryStockSummary();
                        Console.WriteLine("\nCategory Stock Summary:");
                        foreach (var item in summary)
                        {
                            Console.WriteLine($"{item.Key}: {item.Value} items");
                        }
                        break;

                    case 0:
                        Console.WriteLine("Exiting application...");
                        break;

                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }

            } while (choice != 0);
        }
    }
}
