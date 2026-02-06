using System;
using System.Collections.Generic;
using System.Linq;

namespace OnlineFoodDelivery
{
    // ===================== Restaurant Class =====================
    public class Restaurant
    {
        public int RestaurantId { get; private set; }
        public string Name { get; set; }
        public string CuisineType { get; set; }
        public string Location { get; set; }
        public double DeliveryCharge { get; set; }

        public Restaurant(int id, string name, string cuisine, string location, double charge)
        {
            RestaurantId = id;
            Name = name;
            CuisineType = cuisine;
            Location = location;
            DeliveryCharge = charge;
        }
    }

    // ===================== Food Item Class =====================
    public class FoodItem
    {
        public int ItemId { get; private set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public double Price { get; set; }
        public int RestaurantId { get; set; }

        public FoodItem(int id, string name, string category, double price, int restaurantId)
        {
            ItemId = id;
            Name = name;
            Category = category;
            Price = price;
            RestaurantId = restaurantId;
        }
    }

    // ===================== Order Class =====================
    public class Order
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public List<FoodItem> Items { get; set; }
        public DateTime OrderTime { get; set; }
        public string Status { get; set; }   // Pending / Delivered / Cancelled
        public double TotalAmount { get; set; }
    }

    // ===================== Delivery Manager =====================
    public class DeliveryManager
    {
        private readonly List<Restaurant> restaurants = new List<Restaurant>();
        private readonly List<FoodItem> foodItems = new List<FoodItem>();
        private readonly List<Order> orders = new List<Order>();

        private int nextRestaurantId = 1;
        private int nextItemId = 1;
        private int nextOrderId = 1;

        // Add Restaurant
        public void AddRestaurant(string name, string cuisine, string location, double charge)
        {
            if (charge < 0)
                throw new ArgumentException("Delivery charge cannot be negative.");

            restaurants.Add(new Restaurant(nextRestaurantId++, name, cuisine, location, charge));
        }

        // Add Food Item
        public void AddFoodItem(int restaurantId, string name, string category, double price)
        {
            if (!restaurants.Any(r => r.RestaurantId == restaurantId))
                throw new Exception("Restaurant not found.");

            foodItems.Add(new FoodItem(nextItemId++, name, category, price, restaurantId));
        }

        // Group Restaurants by Cuisine
        public Dictionary<string, List<Restaurant>> GroupRestaurantsByCuisine()
        {
            return restaurants
                .GroupBy(r => r.CuisineType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Place Order
        public bool PlaceOrder(int customerId, List<int> itemIds)
        {
            var items = foodItems.Where(i => itemIds.Contains(i.ItemId)).ToList();

            if (!items.Any())
                return false;

            int restaurantId = items.First().RestaurantId;

            // Ensure all items belong to same restaurant
            if (items.Any(i => i.RestaurantId != restaurantId))
                return false;

            Restaurant restaurant = restaurants.First(r => r.RestaurantId == restaurantId);

            double total = items.Sum(i => i.Price) + restaurant.DeliveryCharge;

            orders.Add(new Order
            {
                OrderId = nextOrderId++,
                CustomerId = customerId,
                Items = items,
                OrderTime = DateTime.Now,
                Status = "Pending",
                TotalAmount = total
            });

            return true;
        }

        // Get Pending Orders
        public List<Order> GetPendingOrders()
        {
            return orders
                .Where(o => o.Status == "Pending")
                .OrderBy(o => o.OrderTime)
                .ToList();
        }

        public List<Restaurant> GetAllRestaurants() => restaurants;
        public List<FoodItem> GetAllFoodItems() => foodItems;
    }

    // ===================== Program Class =====================
    class Program
    {
        public static void Main()
        {
            DeliveryManager manager = new DeliveryManager();

            while (true)
            {
                Console.WriteLine("\n===== Online Food Delivery =====");
                Console.WriteLine("1. Add Restaurant");
                Console.WriteLine("2. Add Food Item");
                Console.WriteLine("3. Group Restaurants by Cuisine");
                Console.WriteLine("4. Place Order");
                Console.WriteLine("5. View Pending Orders");
                Console.WriteLine("6. View All Restaurants");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Restaurant Name: ");
                            string rname = Console.ReadLine();

                            Console.Write("Cuisine Type: ");
                            string cuisine = Console.ReadLine();

                            Console.Write("Location: ");
                            string location = Console.ReadLine();

                            Console.Write("Delivery Charge: ");
                            double charge = double.Parse(Console.ReadLine());

                            manager.AddRestaurant(rname, cuisine, location, charge);
                            Console.WriteLine("Restaurant added successfully.");
                            break;

                        case 2:
                            Console.Write("Restaurant ID: ");
                            int rid = int.Parse(Console.ReadLine());

                            Console.Write("Food Name: ");
                            string fname = Console.ReadLine();

                            Console.Write("Category: ");
                            string category = Console.ReadLine();

                            Console.Write("Price: ");
                            double price = double.Parse(Console.ReadLine());

                            manager.AddFoodItem(rid, fname, category, price);
                            Console.WriteLine("Food item added successfully.");
                            break;

                        case 3:
                            var grouped = manager.GroupRestaurantsByCuisine();
                            foreach (var group in grouped)
                            {
                                Console.WriteLine($"\nCuisine: {group.Key}");
                                foreach (var r in group.Value)
                                {
                                    Console.WriteLine($"ID: {r.RestaurantId}, Name: {r.Name}, Location: {r.Location}");
                                }
                            }
                            break;

                        case 4:
                            Console.Write("Customer ID: ");
                            int customerId = int.Parse(Console.ReadLine());

                            Console.Write("Enter Item IDs (comma separated): ");
                            List<int> itemIds = Console.ReadLine()
                                .Split(',')
                                .Select(int.Parse)
                                .ToList();

                            bool ordered = manager.PlaceOrder(customerId, itemIds);
                            Console.WriteLine(ordered
                                ? "Order placed successfully."
                                : "Order failed (invalid items or mixed restaurants).");
                            break;

                        case 5:
                            var pending = manager.GetPendingOrders();
                            foreach (var o in pending)
                            {
                                Console.WriteLine($"Order ID: {o.OrderId}, Customer: {o.CustomerId}, Total: ₹{o.TotalAmount:F2}");
                            }
                            break;

                        case 6:
                            foreach (var r in manager.GetAllRestaurants())
                            {
                                Console.WriteLine($"{r.RestaurantId} | {r.Name} | {r.CuisineType} | {r.Location}");
                            }
                            break;

                        case 0:
                            return;

                        default:
                            Console.WriteLine("Invalid option.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
