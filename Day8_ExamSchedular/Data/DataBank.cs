using System;
using System.Collections.Generic;
using System.Text;
using ExamSchedule.Model;

namespace ExamSchedule.Data
{
    public static class DataBank
    {
        private static List<Student> Students = [];

        static DataBank()
        {
            Students.Add(new Student { Id = 1, Name = "Annu" });
            Students.Add(new Student { Id = 2, Name = "Harry" });
            Students.Add(new Student { Id = 3, Name = "Harsh" });
            Students.Add(new Student { Id = 4, Name = "Alice" });
        }

        public static List<Student> GetStudents()
        {
            return Students;
        }
    }
}