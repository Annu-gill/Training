using System;
using System.Collections.Generic;
using System.Linq;

namespace StudentGradeManagement
{
    // ===================== Student Class =====================
    public class Student
    {
        public int StudentId { get; private set; }
        public string Name { get; set; }
        public string GradeLevel { get; set; }
        public Dictionary<string, double> Subjects { get; set; }

        public Student(int id, string name, string gradeLevel)
        {
            StudentId = id;
            Name = name;
            GradeLevel = gradeLevel;
            Subjects = new Dictionary<string, double>();
        }

        public double GetAverage()
        {
            return Subjects.Count == 0 ? 0 : Subjects.Values.Average();
        }
    }

    // ===================== School Manager =====================
    public class SchoolManager
    {
        private readonly List<Student> students = new List<Student>();
        private int nextStudentId = 1;

        // Add Student
        public void AddStudent(string name, string gradeLevel)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Student name cannot be empty.");

            Student student = new Student(nextStudentId++, name, gradeLevel);
            students.Add(student);
        }

        // Add Grade
        public void AddGrade(int studentId, string subject, double grade)
        {
            if (grade < 0 || grade > 100)
                throw new ArgumentException("Grade must be between 0 and 100.");

            Student student = students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
                throw new Exception("Student not found.");

            student.Subjects[subject] = grade;
        }

        // Group Students by Grade Level
        public SortedDictionary<string, List<Student>> GroupStudentsByGradeLevel()
        {
            return new SortedDictionary<string, List<Student>>(
                students.GroupBy(s => s.GradeLevel)
                        .ToDictionary(g => g.Key, g => g.ToList())
            );
        }

        // Calculate Student Average
        public double CalculateStudentAverage(int studentId)
        {
            Student student = students.FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
                throw new Exception("Student not found.");

            return student.GetAverage();
        }

        // Calculate Subject Averages
        public Dictionary<string, double> CalculateSubjectAverages()
        {
            return students
                .SelectMany(s => s.Subjects)
                .GroupBy(sub => sub.Key)
                .ToDictionary(g => g.Key, g => g.Average(x => x.Value));
        }

        // Get Top Performers
        public List<Student> GetTopPerformers(int count)
        {
            return students
                .OrderByDescending(s => s.GetAverage())
                .Take(count)
                .ToList();
        }

        public List<Student> GetAllStudents()
        {
            return students;
        }
    }

    // ===================== Program Class =====================
    class Program
    {
        public static void Main()
        {
            SchoolManager manager = new SchoolManager();

            while (true)
            {
                Console.WriteLine("\n===== School Management System =====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. Add Grade");
                Console.WriteLine("3. Group Students by Grade Level");
                Console.WriteLine("4. Calculate Student Average");
                Console.WriteLine("5. Subject-wise Averages");
                Console.WriteLine("6. Top Performers");
                Console.WriteLine("7. View All Students");
                Console.WriteLine("0. Exit");
                Console.Write("Choose an option: ");

                int choice = int.Parse(Console.ReadLine());

                try
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Write("Enter Name: ");
                            string name = Console.ReadLine();
                            Console.Write("Enter Grade Level (9th/10th/11th/12th): ");
                            string gradeLevel = Console.ReadLine();
                            manager.AddStudent(name, gradeLevel);
                            Console.WriteLine("Student added successfully.");
                            break;

                        case 2:
                            Console.Write("Enter Student ID: ");
                            int id = int.Parse(Console.ReadLine());
                            Console.Write("Enter Subject: ");
                            string subject = Console.ReadLine();
                            Console.Write("Enter Grade (0-100): ");
                            double grade = double.Parse(Console.ReadLine());
                            manager.AddGrade(id, subject, grade);
                            Console.WriteLine("Grade added successfully.");
                            break;

                        case 3:
                            var grouped = manager.GroupStudentsByGradeLevel();
                            foreach (var group in grouped)
                            {
                                Console.WriteLine($"\nGrade Level: {group.Key}");
                                foreach (var student in group.Value)
                                    Console.WriteLine($"ID: {student.StudentId}, Name: {student.Name}");
                            }
                            break;

                        case 4:
                            Console.Write("Enter Student ID: ");
                            int avgId = int.Parse(Console.ReadLine());
                            Console.WriteLine($"Average: {manager.CalculateStudentAverage(avgId):F2}");
                            break;

                        case 5:
                            var subjectAverages = manager.CalculateSubjectAverages();
                            foreach (var sub in subjectAverages)
                                Console.WriteLine($"{sub.Key}: {sub.Value:F2}");
                            break;

                        case 6:
                            Console.Write("Enter number of top students: ");
                            int count = int.Parse(Console.ReadLine());
                            var toppers = manager.GetTopPerformers(count);
                            foreach (var s in toppers)
                                Console.WriteLine($"ID: {s.StudentId}, Name: {s.Name}, Avg: {s.GetAverage():F2}");
                            break;

                        case 7:
                            foreach (var s in manager.GetAllStudents())
                                Console.WriteLine($"ID: {s.StudentId}, Name: {s.Name}, Grade: {s.GradeLevel}");
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
