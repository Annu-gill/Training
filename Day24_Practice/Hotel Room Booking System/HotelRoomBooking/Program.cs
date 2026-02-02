using System;
using System.Collections.Generic;
using System.Linq;

namespace HotelRoomBooking
{
    // Room class
    public class Room
    {
        public int RoomNumber { get; set; }
        public string RoomType { get; set; }   // Single / Double / Suite
        public double PricePerNight { get; set; }
        public bool IsAvailable { get; set; } = true;

        public override string ToString()
        {
            return $"Room {RoomNumber} | {RoomType} | ₹{PricePerNight}/night";
        }
    }

    // Manager class
    public class HotelManager
    {
        private Dictionary<int, Room> rooms = new Dictionary<int, Room>();

        // Add room if room number does not exist
        public void AddRoom(int roomNumber, string type, double price)
        {
            if (!rooms.ContainsKey(roomNumber))
            {
                rooms.Add(roomNumber, new Room
                {
                    RoomNumber = roomNumber,
                    RoomType = type,
                    PricePerNight = price
                });
            }
        }

        // Group available rooms by type
        public Dictionary<string, List<Room>> GroupRoomsByType()
        {
            Dictionary<string, List<Room>> result = new Dictionary<string, List<Room>>();

            foreach (var room in rooms.Values.Where(r => r.IsAvailable))
            {
                if (!result.ContainsKey(room.RoomType))
                {
                    result[room.RoomType] = new List<Room>();
                }
                result[room.RoomType].Add(room);
            }

            return result;
        }

        // Book room if available
        public bool BookRoom(int roomNumber, int nights)
        {
            if (rooms.ContainsKey(roomNumber) && rooms[roomNumber].IsAvailable)
            {
                Room room = rooms[roomNumber];
                double totalCost = room.PricePerNight * nights;

                room.IsAvailable = false;
                Console.WriteLine($"Room booked successfully!");
                Console.WriteLine($"Total cost for {nights} night(s): ₹{totalCost}");

                return true;
            }

            Console.WriteLine("Room not available or does not exist.");
            return false;
        }

        // Get available rooms within price range
        public List<Room> GetAvailableRoomsByPriceRange(double min, double max)
        {
            return rooms.Values
                        .Where(r => r.IsAvailable &&
                                    r.PricePerNight >= min &&
                                    r.PricePerNight <= max)
                        .ToList();
        }
    }

    // Main program
    public class Program
    {
        public static void Main()
        {
            HotelManager hotel = new HotelManager();

            // 1. Add rooms
            hotel.AddRoom(101, "Single", 2500);
            hotel.AddRoom(102, "Double", 4000);
            hotel.AddRoom(201, "Suite", 7500);
            hotel.AddRoom(202, "Double", 4200);

            // 2. Display available rooms grouped by type
            Console.WriteLine("\nAvailable Rooms by Type:\n");
            var groupedRooms = hotel.GroupRoomsByType();

            foreach (var group in groupedRooms)
            {
                Console.WriteLine(group.Key + " Rooms:");
                foreach (var room in group.Value)
                {
                    Console.WriteLine("  " + room);
                }
                Console.WriteLine();
            }

            // 3. Book a room
            hotel.BookRoom(102, 3);

            // 4. Find rooms within budget
            Console.WriteLine("\nRooms within budget ₹2000 - ₹5000:\n");
            var budgetRooms = hotel.GetAvailableRoomsByPriceRange(2000, 5000);

            foreach (var room in budgetRooms)
            {
                Console.WriteLine(room);
            }
        }
    }
}
