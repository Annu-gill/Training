// Question 1: 

using System;
using System.Collections.Generic;
using System.Linq;

namespace Day18_Practice
{
    public class ItemOperations
    {
        public static SortedDictionary<string, long> itemDetails =
            new SortedDictionary<string, long>()
            {
                { "Pen", 120 },
                { "Pencil", 80 },
                { "Eraser", 40 },
                { "Book", 200 },
                { "Scale", 60 }
            };

        public static void Execute()
        {
            Console.WriteLine("Enter sold count:");
            long soldCount = long.Parse(Console.ReadLine());

            var foundItems = FindItemDetails(soldCount);

            if (foundItems.Count == 0)
            {
                Console.WriteLine("Invalid sold count");
            }
            else
            {
                Console.WriteLine("Item Details:");
                foreach (var item in foundItems)
                {
                    Console.WriteLine($"{item.Key} : {item.Value}");
                }
            }

            Console.WriteLine("\nMinimum and Maximum Sold Items:");
            var minMaxItems = FindMinandMaxSoldItems();
            Console.WriteLine("Minimum Sold Item: " + minMaxItems[0]);
            Console.WriteLine("Maximum Sold Item: " + minMaxItems[1]);

            Console.WriteLine("\nItems Sorted by Sold Count:");
            var sortedItems = SortByCount();
            foreach (var item in sortedItems)
            {
                Console.WriteLine($"{item.Key} : {item.Value}");
            }
        }

        public static SortedDictionary<string, long> FindItemDetails(long soldCount)
        {
            SortedDictionary<string, long> result = new();

            foreach (var item in itemDetails)
            {
                if (item.Value == soldCount)
                {
                    result.Add(item.Key, item.Value);
                }
            }
            return result;
        }

        public static List<string> FindMinandMaxSoldItems()
        {
            List<string> result = new();

            var minItem = itemDetails.OrderBy(i => i.Value).First();
            var maxItem = itemDetails.OrderByDescending(i => i.Value).First();

            result.Add(minItem.Key);
            result.Add(maxItem.Key);

            return result;
        }

        public static Dictionary<string, long> SortByCount()
        {
            return itemDetails
                .OrderBy(i => i.Value)
                .ToDictionary(i => i.Key, i => i.Value);
        }
    }
}
