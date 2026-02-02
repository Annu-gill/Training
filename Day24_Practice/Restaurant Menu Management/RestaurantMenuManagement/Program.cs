using System;
using System.Collections.Generic;
using System.Linq;

namespace RestaurantMenuManagement
{
    // Menu item class
    public class MenuItem
    {
        public string ItemName { get; set; }
        public string Category { get; set; }   // Appetizer / Main Course / Dessert
        public double Price { get; set; }
        public bool IsVegetarian { get; set; }

        public override string ToString()
        {
            string vegTag = IsVegetarian ? "(Veg)" : "(Non-Veg)";
            return $"{ItemName} {vegTag} - ₹{Price}";
        }
    }

    // Menu-Manager class
    public class MenuManager
    {
        private List<MenuItem> menuItems = new List<MenuItem>();

        // Add menu item with price validation
        public void AddMenuItem(string name, string category, double price, bool isVeg)
        {
            if (price <= 0)
            {
                Console.WriteLine("Price must be greater than zero."); 
                return;
            }

            menuItems.Add(new MenuItem
            {
                ItemName = name,
                Category = category,
                Price = price,
                IsVegetarian = isVeg
            });
        }

        // Group items by category
        public Dictionary<string, List<MenuItem>> GroupItemsByCategory()
        {
            Dictionary<string, List<MenuItem>> result =
                new Dictionary<string, List<MenuItem>>();

            foreach (var item in menuItems)
            {
                if (!result.ContainsKey(item.Category))
                {
                    result[item.Category] = new List<MenuItem>();
                }
                result[item.Category].Add(item);
            }

            return result;
        }

        // Get all vegetarian items
        public List<MenuItem> GetVegetarianItems()
        {
            return menuItems.Where(i => i.IsVegetarian).ToList();
        }

        // Calculate average price by category
        public double CalculateAveragePriceByCategory(string category)
        {
            var items = menuItems
                        .Where(i => i.Category.Equals(category, StringComparison.OrdinalIgnoreCase))
                        .ToList();

            if (items.Count == 0)
                return 0;

            return items.Average(i => i.Price);
        }
    }

    // Main program
    class Program
    {
        static void Main()
        {
            MenuManager manager = new MenuManager();

            // 1. Add menu items
            manager.AddMenuItem("Spring Rolls", "Appetizer", 180, true);
            manager.AddMenuItem("Chicken Wings", "Appetizer", 250, false);
            manager.AddMenuItem("Paneer Butter Masala", "Main Course", 320, true);
            manager.AddMenuItem("Grilled Fish", "Main Course", 450, false);
            manager.AddMenuItem("Gulab Jamun", "Dessert", 120, true);

            // 2. Display menu grouped by category
            Console.WriteLine("Menu Categorized by Course:\n");
            var groupedMenu = manager.GroupItemsByCategory();

            foreach (var category in groupedMenu)
            {
                Console.WriteLine(category.Key + ":");
                foreach (var item in category.Value)
                {
                    Console.WriteLine("  " + item);
                }
                Console.WriteLine();
            }

            // 3. Show vegetarian-only menu
            Console.WriteLine("Vegetarian Menu:\n");
            var vegItems = manager.GetVegetarianItems();

            foreach (var item in vegItems)
            {
                Console.WriteLine(item);
            }

            // 4. Calculate average price per category
            Console.WriteLine("\nAverage Price (Main Course):");
            Console.WriteLine("₹" + manager.CalculateAveragePriceByCategory("Main Course"));
        }
    }
}
