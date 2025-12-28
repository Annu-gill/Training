
// // Simple exam scheduling demo.
// // Demonstrates basic OOP concepts such as inheritance and composition.
// // HOD schedules exams for a semester and assigns an examiner to each exam.
// // Run with: dotnet run --project Day2ConditionalLoops

// /// <summary>
// /// Base class representing a user (common fields like Id and Name).
// /// </summary>
// public class User
// {
//     private int id;

//     public int Id 
//     {
//         get
//         {
//             return id;
//         }
//         set
//         {
//             id = value;   
//         }
//     }

//     private string name;
    
//     public string Name 
//     {
//         get
//         {
//             return name;
//         }
//         set
//         {
//             name=value;
//         }
//     }
// }
// /// <summary>
// /// Student inherits from User and contains student-specific properties.
// /// </summary>
// public class Student : User
// {
//     public int Student_id{get;set;}
//     public string Student_name{get;set;}
// }

// /// <summary>
// /// Employee inherits from User and adds organization-specific fields like Designation.
// /// </summary>
// public class Employee : User
// {
//     public string Designation{get;set;}
// }

// /// <summary>
// /// Examiner is a kind of Employee who can evaluate exams.
// /// </summary>
// public class Examiner : Employee
// {
//     // Example method to show Examiner functionality
//     public void EvaluateExam()
//     {
//         // Print the examiner's name when evaluating an exam
//         Console.WriteLine($"Examiner is {Name}.");
//     }
// }

// /// <summary>
// /// Represents an academic semester.
// /// </summary>
// public class Semester
// {
//     public int Semester_no{get;set;}
// }

// /// <summary>
// /// Exam represents an exam event, with date, room and assigned examiner.
// /// </summary>
// public class Exam
// {
//     public int Exam_id{get;set;}
//     public DateTime ExamDate{get;set;}
//     public string Exam_room{get;set;}
//     public Examiner AssignedExaminer{get;set;}
// }

// /// <summary>
// /// Holds the scheduled exam details for a semester and can display the schedule.
// /// </summary>
// public class ExamSchedule
// {
//     public Semester Semester { get; set; }
//     public Exam Exam { get; set; }

//     // Print the schedule details to the console
//     public void DisplaySchedule()
//     {
//         Console.WriteLine($"Semester: {Semester.Semester_no}");
//         Console.WriteLine($"Exam ID: {Exam.Exam_id}");
//         Console.WriteLine($"Date: {Exam.ExamDate}");
//         Console.WriteLine($"Room: {Exam.Exam_room}");
//         Console.WriteLine($"Examiner: {Exam.AssignedExaminer.Name}");
//     }
// }

// /// <summary>
// /// Head of Department (HOD) who can schedule exams and assign examiners.
// /// </summary>
// public class HOD : Employee
// {
//     // Schedule an exam for a semester and return the created ExamSchedule
//     public ExamSchedule ScheduleExam(Semester semester, Exam exam)
//     {
//         Console.WriteLine($"HOD {Name} scheduled exam for Semester {semester.Semester_no}");
//         return new ExamSchedule
//         {
//             Semester = semester,
//             Exam = exam
//         };
//     }

//     // Assign an Examiner to a specific Exam
//     public void AssignExaminer(Exam exam, Examiner examiner)
//     {
//         exam.AssignedExaminer = examiner;
//         Console.WriteLine($"Examiner {examiner.Name} assigned to Exam {exam.Exam_id}");
//     }
// }


// class Program
// {
//     static void Main()
//     {
//         // Create a HOD object from user input
//         HOD hod = new HOD();
//         Console.Write("Enter HOD ID: ");
//         hod.Id = int.Parse(Console.ReadLine()); // Consider TryParse to make input robust

//         Console.Write("Enter HOD Name: ");
//         hod.Name = Console.ReadLine();
//         hod.Designation = "HOD";

//         // Create and populate Semester
//         Semester semester = new Semester();
//         Console.Write("\nEnter Semester Number: ");
//         semester.Semester_no = int.Parse(Console.ReadLine());

//         // Create and populate Examiner
//         Examiner examiner = new Examiner();
//         Console.Write("\nEnter Examiner ID: ");
//         examiner.Id = int.Parse(Console.ReadLine());

//         Console.Write("Enter Examiner Name: ");
//         examiner.Name = Console.ReadLine();
//         examiner.Designation = "Examiner";

//         // Create and populate Exam
//         Exam exam = new Exam();
//         Console.Write("\nEnter Exam ID: ");
//         exam.Exam_id = int.Parse(Console.ReadLine());

//         Console.Write("Enter Exam Date (yyyy-mm-dd): ");
//         exam.ExamDate = DateTime.Parse(Console.ReadLine()); // Consider DateTime.TryParse for safer parsing

//         Console.Write("Enter Exam Room: ");
//         exam.Exam_room = Console.ReadLine();

//         // Process: assign examiner and schedule the exam
//         hod.AssignExaminer(exam, examiner);
//         ExamSchedule schedule = hod.ScheduleExam(semester, exam);

//         // Output: display the scheduled exam details
//         schedule.DisplaySchedule();
//     }
// }
