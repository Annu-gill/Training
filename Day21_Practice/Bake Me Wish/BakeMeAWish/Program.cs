using System;
using System.Collections.Generic;

class CakeOrder
{
    // Holds Order ID as Key and Cake Cost as Value
    private Dictionary<string, double> orderMap = new Dictionary<string, double>();

    // Add order details
    public void addOrderDetails(string orderId, double cakeCost)
    {
        orderMap[orderId] = cakeCost;
    }

    // Find orders above the specified cost
    public Dictionary<string, double> findOrdersAboveSpecifiedCost(double cakeCost)
    {
        Dictionary<string, double> result = new Dictionary<string, double>();

        foreach (var order in orderMap)
        {
            if (order.Value > cakeCost)
            {
                result.Add(order.Key, order.Value);
            }
        }

        return result;
    }
}

class UserInterface
{
    public static void Main()
    {
        CakeOrder cakeOrder = new CakeOrder();

        Console.WriteLine("Enter number of cake orders to be added");
        int n = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the cake order details (Order Id: CakeCost)");

        for (int i = 0; i < n; i++)
        {
            string input = Console.ReadLine();
            string[] parts = input.Split(':');

            string orderId = parts[0].Trim();
            double cakeCost = double.Parse(parts[1].Trim());

            cakeOrder.addOrderDetails(orderId, cakeCost);
        }

        Console.WriteLine("Enter the cost to search the cake orders");
        double searchCost = double.Parse(Console.ReadLine());

        Dictionary<string, double> filteredOrders =
            cakeOrder.findOrdersAboveSpecifiedCost(searchCost);

        if (filteredOrders.Count == 0)
        {
            Console.WriteLine("No cake orders found");
        }
        else
        {
            Console.WriteLine("Cake Orders above the specified cost");
            foreach (var order in filteredOrders)
            {
                Console.WriteLine(
                    $"Order ID: {order.Key}, Cake Cost: {order.Value:F1}"
                );
            }
        }
    }
}