using System;
using System.Collections.Generic;
using System.Linq;

// ===================== BASE INTERFACE =====================
public interface IProduct
{
    int Id { get; }
    string Name { get; }
    decimal Price { get; }
    Category Category { get; }
}

public enum Category { Electronics, Clothing, Books, Groceries }

// ===================== GENERIC REPOSITORY =====================
public class ProductRepository<T> where T : class, IProduct
{
    private List<T> _products = new List<T>();

    // Add product with validation
    public void AddProduct(T product)
    {
        if (product == null)
            throw new ArgumentNullException("Product cannot be null");

        // Rule 1: Unique ID
        if (_products.Any(p => p.Id == product.Id))
            throw new InvalidOperationException("Product ID must be unique");

        // Rule 2: Price must be positive
        if (product.Price <= 0)
            throw new ArgumentException("Price must be positive");

        // Rule 3: Name cannot be empty
        if (string.IsNullOrWhiteSpace(product.Name))
            throw new ArgumentException("Product name cannot be empty");

        _products.Add(product);
    }

    // Find products by predicate
    public IEnumerable<T> FindProducts(Func<T, bool> predicate)
    {
        return _products.Where(predicate);
    }

    // Total inventory value
    public decimal CalculateTotalValue()
    {
        return _products.Sum(p => p.Price);
    }

    public List<T> GetAll() => _products;
}

// ===================== ELECTRONIC PRODUCT =====================
public class ElectronicProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Electronics;
    public int WarrantyMonths { get; set; }
    public string Brand { get; set; }
}

// ===================== CLOTHING PRODUCT =====================
public class ClothingProduct : IProduct
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public Category Category => Category.Clothing;
    public string Size { get; set; }
}

// ===================== DISCOUNT WRAPPER =====================
public class DiscountedProduct<T> where T : IProduct
{
    private T _product;
    private decimal _discountPercentage;

    public DiscountedProduct(T product, decimal discountPercentage)
    {
        if (product == null)
            throw new ArgumentNullException("Product cannot be null");

        if (discountPercentage < 0 || discountPercentage > 100)
            throw new ArgumentException("Discount must be between 0 and 100");

        _product = product;
        _discountPercentage = discountPercentage;
    }

    public decimal DiscountedPrice =>
        _product.Price * (1 - _discountPercentage / 100);

    public override string ToString()
    {
        return $"{_product.Name} | Original: {_product.Price} | Discount: {_discountPercentage}% | Final: {DiscountedPrice}";
    }
}

// ===================== INVENTORY MANAGER =====================
public class InventoryManager
{
    public void ProcessProducts<T>(IEnumerable<T> products) where T : IProduct
    {
        Console.WriteLine("\nAll Products:");
        foreach (var p in products)
            Console.WriteLine($"{p.Name} - {p.Price}");

        // Most expensive
        var expensive = products.OrderByDescending(p => p.Price).FirstOrDefault();
        Console.WriteLine($"\nMost Expensive: {expensive?.Name} - {expensive?.Price}");

        // Group by category
        Console.WriteLine("\nGrouped by Category:");
        var groups = products.GroupBy(p => p.Category);

        foreach (var g in groups)
        {
            Console.WriteLine($"\nCategory: {g.Key}");
            foreach (var p in g)
                Console.WriteLine(p.Name);
        }

        // Apply discount to electronics > 500
        Console.WriteLine("\nDiscounted Electronics > 500:");
        var discounted = products
            .Where(p => p.Category == Category.Electronics && p.Price > 500)
            .Select(p => new DiscountedProduct<T>(p, 10));

        foreach (var d in discounted)
            Console.WriteLine(d);
    }

    // Bulk update
    public void UpdatePrices<T>(List<T> products, Func<T, decimal> priceAdjuster)
        where T : IProduct
    {
        for (int i = 0; i < products.Count; i++)
        {
            try
            {
                decimal newPrice = priceAdjuster(products[i]);

                // Since IProduct has no setter, we update via reflection
                var prop = products[i].GetType().GetProperty("Price");
                if (prop != null && prop.CanWrite)
                    prop.SetValue(products[i], newPrice);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error updating {products[i].Name}: {ex.Message}");
            }
        }
    }
}

// ===================== TEST PROGRAM =====================
class Program
{
    static void Main()
    {
        var repo = new ProductRepository<ElectronicProduct>();

        try
        {
            // Sample products
            repo.AddProduct(new ElectronicProduct
            {
                Id = 1,
                Name = "Laptop",
                Price = 900,
                Brand = "Dell",
                WarrantyMonths = 24
            });

            repo.AddProduct(new ElectronicProduct
            {
                Id = 2,
                Name = "Phone",
                Price = 700,
                Brand = "Samsung",
                WarrantyMonths = 12
            });

            repo.AddProduct(new ElectronicProduct
            {
                Id = 3,
                Name = "Headphones",
                Price = 150,
                Brand = "Sony",
                WarrantyMonths = 12
            });

            repo.AddProduct(new ElectronicProduct
            {
                Id = 4,
                Name = "TV",
                Price = 1200,
                Brand = "LG",
                WarrantyMonths = 36
            });

            repo.AddProduct(new ElectronicProduct
            {
                Id = 5,
                Name = "Mouse",
                Price = 50,
                Brand = "Logitech",
                WarrantyMonths = 6
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        // Finding by brand
        Console.WriteLine("\nProducts by brand Samsung:");
        var samsung = repo.FindProducts(p => p.Brand == "Samsung");
        foreach (var p in samsung)
            Console.WriteLine(p.Name);

        // Total value
        Console.WriteLine($"\nTotal Inventory Value: {repo.CalculateTotalValue()}");

        // Discount demo
        var laptop = repo.GetAll().First();
        var discount = new DiscountedProduct<ElectronicProduct>(laptop, 15);
        Console.WriteLine("\nDiscount Example:");
        Console.WriteLine(discount);

        // Mixed collection
        List<IProduct> mixed = new List<IProduct>(repo.GetAll());
        mixed.Add(new ClothingProduct
        {
            Id = 10,
            Name = "T-Shirt",
            Price = 30,
            Size = "M"
        });

        // Process inventory
        var manager = new InventoryManager();
        manager.ProcessProducts(mixed);

        // Update prices (increase by 5%)
        manager.UpdatePrices(repo.GetAll(), p => p.Price * 1.05m);

        Console.WriteLine("\nAfter Price Update:");
        foreach (var p in repo.GetAll())
            Console.WriteLine($"{p.Name} - {p.Price}");
    }
}
