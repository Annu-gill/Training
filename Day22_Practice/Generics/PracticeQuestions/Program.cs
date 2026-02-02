// // Task 1: make student class, take two marks and take average for it and store in collections and calculate top 5 students in c#

// using System;
// using System.Collections.Generic;
// using System.Linq;

// public class Student
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public double Mark1 { get; set; }
//     public double Mark2 { get; set; }

//     public double Average
//     {
//         get { return (Mark1 + Mark2) / 2; }
//     }
// }
// class Program
// {
//     public static void Main()
//     {
//         List<Student> students = new List<Student>
//         {
//             new Student { Id = 1, Name = "Annu", Mark1 = 85, Mark2 = 90 },
//             new Student { Id = 2, Name = "Ravi", Mark1 = 78, Mark2 = 88 },
//             new Student { Id = 3, Name = "Sneha", Mark1 = 92, Mark2 = 95 },
//             new Student { Id = 4, Name = "Amit", Mark1 = 70, Mark2 = 75 },
//             new Student { Id = 5, Name = "Priya", Mark1 = 88, Mark2 = 91 },
//             new Student { Id = 6, Name = "Karan", Mark1 = 80, Mark2 = 82 },
//             new Student { Id = 7, Name = "Neha", Mark1 = 94, Mark2 = 96 }
//         };

//         var top5Students = students
//                             .OrderByDescending(s => s.Average)
//                             .Take(5)
//                             .ToList();

//         Console.WriteLine("\nTop 5 Students:\n");

//         foreach (var student in top5Students)
//         {
//             Console.WriteLine(
//                 $"Id: {student.Id}\t Name: {student.Name}\t Average: {student.Average}"
//             );
//         }
//     }
// }


// //  Task 2: Make a delegate and those whose average is less than 60%, then a delegate of NotifyStudent should be there giving them notification about improvemmentin C#

// using System;
// using System.Collections.Generic;

// /// <summary>
// /// Represents a student with two marks and a calculated average.
// /// </summary>
// public class Student
// {
//     // Unique identifier for the student
//     public int Id { get; set; }

//     // Student name
//     public string Name { get; set; }

//     // First subject marks
//     public double Mark1 { get; set; }

//     // Second subject marks
//     public double Mark2 { get; set; }

//     // Read-only property to calculate average marks
//     public double Average
//     {
//         get { return (Mark1 + Mark2) / 2; }
//     }
// }

// /// <summary>
// /// Delegate that defines the notification method signature.
// /// </summary>
// public delegate void NotifyStudent(Student student);

// /// <summary>
// /// Handles student notifications related to academic improvement.
// /// </summary>
// public class StudentNotifier
// {
//     /// <summary>
//     /// Sends a notification to students whose average is below 60%.
//     /// </summary>
//     public static void SendImprovementNotification(Student student)
//     {
//         Console.WriteLine(
//             $"Notification:\t{student.Name}, your average is {student.Average}. Please work on improving your performance."
//         );
//     }
// }

// class Program
// {
//     static void Main()
//     {
//         // Creating a collection of students
//         List<Student> students = new List<Student>
//         {
//             new Student { Id = 1, Name = "Vansh",   Mark1 = 85, Mark2 = 90 },
//             new Student { Id = 2, Name = "Ravi",    Mark1 = 78, Mark2 = 88 },
//             new Student { Id = 3, Name = "Sneha",   Mark1 = 92, Mark2 = 95 },
//             new Student { Id = 4, Name = "Tanisha", Mark1 = 55, Mark2 = 58 },
//             new Student { Id = 5, Name = "Ravin",   Mark1 = 75, Mark2 = 70 },
//             new Student { Id = 6, Name = "Mohit",   Mark1 = 45, Mark2 = 50 },
//             new Student { Id = 7, Name = "Amit",    Mark1 = 50, Mark2 = 62 }
//         };

//         // Creating delegate instance and assigning method reference
//         NotifyStudent notifyDelegate = StudentNotifier.SendImprovementNotification;

//         // Checking students whose average is less than 60%
//         foreach (var student in students)
//         {
//             if (student.Average < 60)
//             {
//                 // Invoking delegate to notify student
//                 notifyDelegate(student);
//             }
//         }

//         Console.ReadLine();
//     }
// }



// namespace PracticeQuestions
// {
//     public delegate void Notify();
//     public class Student : IComparable<Student>
//     {
//         public string Name { get; set; }
//         public int Marks { get; set; }

//         public int CompareTo(Student? other)
//         {
//             return other.Marks.CompareTo(this.Marks);
//         }

//         public event Notify OnNotify;

//         public void NeedImpovement()
//         {
//             Console.WriteLine("Need Impovement");
//         }

//         public void GoodStudent()
//         {
//             Console.WriteLine("Good Student");
//         }

//         public void AverageStudent()
//         {
//             Console.WriteLine("Average Student");
//         }

//         public void SendNotification(Student s)
//         {
//             OnNotify = null;

//             if (s.Marks <= 500)
//             {
//                 OnNotify = NeedImpovement;
//             }
//             else if (s.Marks >= 560)
//             {
//                 OnNotify = GoodStudent;
//             }
//             else
//             {
//                 OnNotify = AverageStudent;
//             }
//             OnNotify?.Invoke();
//         }
//     }
//     public class Program
//     {
//         static void Main(string[] args)
//         {
//             Student s = new Student();
//             List<Student> students = new List<Student>();
//             students.Add(new Student
//             {
//                 Name = "Vishwajeet",
//                 Marks = 500
//             });
//             students.Add(new Student
//             {
//                 Name = "Thiluck",
//                 Marks = 450
//             });
//             students.Add(new Student
//             {
//                 Name = "Pratham",
//                 Marks = 550
//             });
//             students.Add(new Student
//             {
//                 Name = "Harsha",
//                 Marks = 600
//             });
//             students.Add(new Student
//             {
//                 Name = "Annu",
//                 Marks = 560
//             });
//             students.Sort();
//             int rank = 1;
//             foreach(Student student in students)
//             {
//                 Console.Write($"Rank = {rank++} Name = {student.Name}, Marks = {student.Marks}, Remarks: ");
//                 s.SendNotification(student);
//                 Console.WriteLine();
//             }
//         }
//     }
// }


// make example for Action, Predicate, function for this code  in C#



using System;
using System.Collections.Generic;

namespace PracticeQuestions
{
    /// <summary>
    /// Student class implements IComparable to support ranking by marks
    /// </summary>
    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Marks { get; set; }

        // Sort students in descending order of marks
        public int CompareTo(Student? other)
        {
            return other.Marks.CompareTo(this.Marks);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Create list of students
            List<Student> students = new List<Student>
            {
                new Student { Name = "Vishwajeet", Marks = 500 },
                new Student { Name = "Thiluck", Marks = 450 },
                new Student { Name = "Pratham", Marks = 550 },
                new Student { Name = "Harsha", Marks = 600 },
                new Student { Name = "Annu", Marks = 560 }
            };

            // Sort students by marks (Ranking)
            students.Sort();

            // PREDICATE --- checks the marks
            // Checks a condition and returns true/false
            // Checks whether a student needs improvement
            Predicate<Student> needImprovement = s => s.Marks <= 500;

            // Checks whether a student is a good student
            Predicate<Student> goodStudent = s => s.Marks >= 560;

            // FUNC --- deciding the remarks
            // Takes input and returns a value
            // Returns remark string based on student's marks
            Func<Student, string> getRemark = s =>
            {
                if (needImprovement(s))
                    return "Need Improvement";
                else if (goodStudent(s))
                    return "Good Student";
                else
                    return "Average Student";
            };

            // ACTION --- printing the output
            // Performs an operation without returning anything
            // Prints student rank, details, and remark
            Action<Student, int> printStudentDetails = (student, rank) =>
            {
                Console.WriteLine(
                    $"Rank = {rank}, Name = {student.Name}, Marks = {student.Marks}, Remarks: {getRemark(student)}"
                );
            };

            // Display student ranking and remarks
            int rank = 1;
            foreach (Student student in students)
            {
                printStudentDetails(student, rank++);
            }

            Console.ReadLine();
        }
    }
}
