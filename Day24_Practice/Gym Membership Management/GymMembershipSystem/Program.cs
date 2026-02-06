using System;
using System.Collections.Generic;
using System.Linq;

namespace GymMembershipSystem
{
    // ===================== Member Class =====================
    public class Member
    {
        public int MemberId { get; private set; }
        public string Name { get; set; }
        public string MembershipType { get; set; }
        public DateTime JoinDate { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Member(int id, string name, string type, int months)
        {
            MemberId = id;
            Name = name;
            MembershipType = type;
            JoinDate = DateTime.Now;
            ExpiryDate = JoinDate.AddMonths(months);
        }

        public bool IsActive()
        {
            return ExpiryDate >= DateTime.Now;
        }
    }

    // ===================== Fitness Class =====================
    public class FitnessClass
    {
        public string ClassName { get; set; }
        public string Instructor { get; set; }
        public DateTime Schedule { get; set; }
        public int MaxParticipants { get; set; }
        public List<int> RegisteredMembers { get; set; } = new List<int>();

        public int AvailableSlots => MaxParticipants - RegisteredMembers.Count;
    }

    // ===================== Gym Manager =====================
    public class GymManager
    {
        private readonly List<Member> members = new List<Member>();
        private readonly List<FitnessClass> classes = new List<FitnessClass>();
        private int nextMemberId = 1;

        // Add Member
        public void AddMember(string name, string membershipType, int months)
        {
            if (months <= 0)
                throw new ArgumentException("Membership duration must be greater than zero.");

            members.Add(new Member(nextMemberId++, name, membershipType, months));
        }

        // Add Class
        public void AddClass(string className, string instructor, DateTime schedule, int maxParticipants)
        {
            if (maxParticipants <= 0)
                throw new ArgumentException("Max participants must be greater than zero.");

            classes.Add(new FitnessClass
            {
                ClassName = className,
                Instructor = instructor,
                Schedule = schedule,
                MaxParticipants = maxParticipants
            });
        }

        // Register for Class
        public bool RegisterForClass(int memberId, string className)
        {
            Member member = members.FirstOrDefault(m => m.MemberId == memberId);
            FitnessClass fitnessClass = classes.FirstOrDefault(c =>
                c.ClassName.Equals(className, StringComparison.OrdinalIgnoreCase));

            if (member == null || fitnessClass == null)
                return false;

            if (!member.IsActive())
                return false;

            if (fitnessClass.AvailableSlots <= 0)
                return false;

            if (fitnessClass.RegisteredMembers.Contains(memberId))
                return false;

            fitnessClass.RegisteredMembers.Add(memberId);
            return true;
        }

        // Group Members by Membership Type
        public Dictionary<string, List<Member>> GroupMembersByMembershipType()
        {
            return members
                .GroupBy(m => m.MembershipType)
                .ToDictionary(g => g.Key, g => g.ToList());
        }

        // Get Upcoming Classes (Next 7 Days)
        public List<FitnessClass> GetUpcomingClasses()
        {
            DateTime today = DateTime.Now;
            DateTime nextWeek = today.AddDays(7);

            return classes
                .Where(c => c.Schedule >= today && c.Schedule <= nextWeek)
                .OrderBy(c => c.Schedule)
                .ToList();
        }

        public List<Member> GetAllMembers() => members;
        public List<FitnessClass> GetAllClasses() => classes;
    }

    // ===================== Program Class =====================
    class Program
    {
        public static void Main()
        {
            GymManager manager = new GymManager();

            while (true)
            {
                Console.WriteLine("\n===== Gym Membership Management =====");
                Console.WriteLine("1. Add Member");
                Console.WriteLine("2. Add Fitness Class");
                Console.WriteLine("3. Register Member for Class");
                Console.WriteLine("4. Group Members by Membership Type");
                Console.WriteLine("5. View Upcoming Classes");
                Console.WriteLine("6. View Class Occupancy");
                Console.WriteLine("0. Exit");
                Console.Write("Choose option: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Member Name: ");
                            string name = Console.ReadLine();

                            Console.Write("Membership Type (Basic/Premium/Platinum): ");
                            string type = Console.ReadLine();

                            Console.Write("Duration (months): ");
                            int months = int.Parse(Console.ReadLine());

                            manager.AddMember(name, type, months);
                            Console.WriteLine("Member added successfully.");
                            break;

                        case 2:
                            Console.Write("Class Name: ");
                            string className = Console.ReadLine();

                            Console.Write("Instructor: ");
                            string instructor = Console.ReadLine();

                            Console.Write("Schedule (yyyy-MM-dd HH:mm): ");
                            DateTime schedule = DateTime.Parse(Console.ReadLine());

                            Console.Write("Max Participants: ");
                            int max = int.Parse(Console.ReadLine());

                            manager.AddClass(className, instructor, schedule, max);
                            Console.WriteLine("Class scheduled successfully.");
                            break;

                        case 3:
                            Console.Write("Member ID: ");
                            int memberId = int.Parse(Console.ReadLine());

                            Console.Write("Class Name: ");
                            string registerClass = Console.ReadLine();

                            bool registered = manager.RegisterForClass(memberId, registerClass);
                            Console.WriteLine(registered
                                ? "Registration successful."
                                : "Registration failed (expired membership or class full).");
                            break;

                        case 4:
                            var grouped = manager.GroupMembersByMembershipType();
                            foreach (var group in grouped)
                            {
                                Console.WriteLine($"\n{group.Key} Members:");
                                foreach (var m in group.Value)
                                {
                                    Console.WriteLine($"ID: {m.MemberId}, Name: {m.Name}, Expiry: {m.ExpiryDate:d}");
                                }
                            }
                            break;

                        case 5:
                            var upcoming = manager.GetUpcomingClasses();
                            foreach (var c in upcoming)
                            {
                                Console.WriteLine($"{c.ClassName} | {c.Schedule} | Instructor: {c.Instructor}");
                            }
                            break;

                        case 6:
                            foreach (var c in manager.GetAllClasses())
                            {
                                Console.WriteLine($"{c.ClassName} | Registered: {c.RegisteredMembers.Count}/{c.MaxParticipants}");
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
