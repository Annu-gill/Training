using System;

namespace Day6
{
    // Interface Example
    public interface IPrint
    {
        void Print();
    }

    public class Printer : IPrint
    {
        public void Print()
        {
            Console.WriteLine("Hello");
        }
    }

    // Base User Class
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    // Student
    public class Student : User
    {
        public int StudentId { get; set; }
    }

    // Employee
    public class Employee : User
    {
        public string Designation { get; set; }
    }

    // Examiner
    public class Examiner : Employee
    {
        public void EvaluateExam()
        {
            Console.WriteLine($"Exam evaluated by {Name}");
        }
    }

    // Semester
    public class Semester
    {
        public int SemesterNo { get; set; }
    }

    // Exam
    public class Exam
    {
        public int ExamId { get; set; }
        public DateTime ExamDate { get; set; }
        public string ExamRoom { get; set; }
        public Examiner AssignedExaminer { get; set; }
    }

    // Exam Schedule
    public class ExamSchedule
    {
        public Semester Semester { get; set; }
        public Exam Exam { get; set; }

        public void DisplaySchedule()
        {
            Console.WriteLine($"Semester       : {Semester.SemesterNo}");
            Console.WriteLine($"Exam ID        : {Exam.ExamId}");
            Console.WriteLine($"Exam Date      : {Exam.ExamDate:yyyy-MM-dd}");
            Console.WriteLine($"Exam Room      : {Exam.ExamRoom}");
            Console.WriteLine($"Examiner       : {Exam.AssignedExaminer.Name}");
        }
    }

    // HOD
    public class HOD : Employee
    {
        public ExamSchedule ScheduleExam(Semester semester, Exam exam)
        {
            Console.WriteLine($"\nHOD {Name} scheduled the exam.");
            return new ExamSchedule
            {
                Semester = semester,
                Exam = exam
            };
        }

        public void AssignExaminer(Exam exam, Examiner examiner)
        {
            exam.AssignedExaminer = examiner;
            Console.WriteLine($"Examiner {examiner.Name} assigned successfully.");
        }
    }
}
