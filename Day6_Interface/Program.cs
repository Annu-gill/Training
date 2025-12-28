using System;

namespace Day6
{
    class Program
    {
        static void Main()
        {
            // HOD Input
            HOD hod = new HOD();
            Console.Write("Enter HOD ID: ");
            hod.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter HOD Name: ");
            hod.Name = Console.ReadLine();
            hod.Designation = "HOD";

            // Semester Input
            Semester semester = new Semester();
            Console.Write("\nEnter Semester Number: ");
            semester.SemesterNo = int.Parse(Console.ReadLine());

            // Examiner Input
            Examiner examiner = new Examiner();
            Console.Write("\nEnter Examiner ID: ");
            examiner.Id = int.Parse(Console.ReadLine());

            Console.Write("Enter Examiner Name: ");
            examiner.Name = Console.ReadLine();
            examiner.Designation = "Examiner";

            // Exam Input
            Exam exam = new Exam();
            Console.Write("\nEnter Exam ID: ");
            exam.ExamId = int.Parse(Console.ReadLine());

            Console.Write("Enter Exam Date (yyyy-mm-dd): ");
            exam.ExamDate = DateTime.Parse(Console.ReadLine());

            Console.Write("Enter Exam Room: ");
            exam.ExamRoom = Console.ReadLine();

            // Process
            hod.AssignExaminer(exam, examiner);
            ExamSchedule schedule = hod.ScheduleExam(semester, exam);

            // Output
            Console.WriteLine("\n--- Exam Schedule ---");
            schedule.DisplaySchedule();
        }
    }
}
