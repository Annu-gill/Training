

// namespace Day6
// {
//     public interface  IPrint
//     {
//         public void Print();
//     }

//     public class Printer : IPrint
//     {
//         public void Print()
//         {
//             System.Console.WriteLine("Hello");
//         }
//     }
//     class Program
//     {
//         public static void Main()
//         {
//             IPrint obj=new Printer();
//             obj.Print();
//         }
//     }
// }


// // As a HOD, I want schedule exam in every semester, and assign examiner for each exam

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
// public class Student : User
// {
//     public int Student_id{get;set;}
//     public string Student_name{get;set;}
// }

// public class Employee : User
// {
//     public string Designation{get;set;}
// }

// public class Examiner : Employee
// {
//     public void EvaluateExam()
//     {
//         Console.WriteLine($"Examiner is {Name}.");
//     }
// }

// public class Semester
// {
//     public int Semester_no{get;set;}
// }

// public class Exam
// {
//     public int Exam_id{get;set;}
//     public DateTime ExamDate{get;set;}
//     public string Exam_room{get;set;}
//     public Examiner AssignedExaminer{get;set;}
// }

// public class ExamSchedule
// {
//     public Semester Semester { get; set; }
//         public Exam Exam { get; set; }
//         public void DisplaySchedule()
//         {
//             Console.WriteLine($"Semester: {Semester.Semester_no}");
//             Console.WriteLine($"Exam ID: {Exam.Exam_id}");
//             Console.WriteLine($"Date: {Exam.ExamDate}");
//             Console.WriteLine($"Room: {Exam.Exam_room}");
//             Console.WriteLine($"Examiner: {Exam.AssignedExaminer.Name}");
//         }
// }

// public class HOD : Employee
// {
//     public ExamSchedule ScheduleExam(Semester semester, Exam exam)
//         {
//             Console.WriteLine($"HOD {Name} scheduled exam for Semester {semester.Semester_no}");
//             return new ExamSchedule
//             {
//                 Semester = semester,
//                 Exam = exam
//             };
//         }

//         public void AssignExaminer(Exam exam, Examiner examiner)
//         {
//             exam.AssignedExaminer = examiner;
//             Console.WriteLine($"Examiner {examiner.Name} assigned to Exam {exam.Exam_id}");
//         }
// }


// class Program
// {
//     static void Main()
//     {
//         // HOD Input
//         HOD hod = new HOD();
//         Console.Write("Enter HOD ID: ");
//         hod.Id = int.Parse(Console.ReadLine());

//         Console.Write("Enter HOD Name: ");
//         hod.Name = Console.ReadLine();

//         hod.Designation = "HOD";

//             // Semester Input
//         Semester semester = new Semester();
//         Console.Write("\nEnter Semester Number: ");
//         semester.Semester_no = int.Parse(Console.ReadLine());

//             // Examiner Input
//         Examiner examiner = new Examiner();
//         Console.Write("\nEnter Examiner ID: ");
//         examiner.Id = int.Parse(Console.ReadLine());

//         Console.Write("Enter Examiner Name: ");
//         examiner.Name = Console.ReadLine();

//         examiner.Designation = "Examiner";

//             // Exam Input
//         Exam exam = new Exam();
//         Console.Write("\nEnter Exam ID: ");
//         exam.Exam_id = int.Parse(Console.ReadLine());

//         Console.Write("Enter Exam Date (yyyy-mm-dd): ");
//         exam.ExamDate = DateTime.Parse(Console.ReadLine());

//         Console.Write("Enter Exam Room: ");
//         exam.Exam_room = Console.ReadLine();

//             // Process
//         hod.AssignExaminer(exam, examiner);
//         ExamSchedule schedule = hod.ScheduleExam(semester, exam);

//             // Output
//         schedule.DisplaySchedule();
//     }
// }
