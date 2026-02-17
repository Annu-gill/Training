using System;
using System.Collections.Generic;
using System.Linq;

// ================= BASE INTERFACES =================
public interface IStudent
{
    int StudentId { get; }
    string Name { get; }
    int Semester { get; }
}

public interface ICourse
{
    string CourseCode { get; }
    string Title { get; }
    int MaxCapacity { get; }
    int Credits { get; }
}

// ================= GENERIC ENROLLMENT SYSTEM =================
public class EnrollmentSystem<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<TCourse, List<TStudent>> _enrollments = new();

    public bool EnrollStudent(TStudent student, TCourse course)
    {
        if (student == null || course == null)
        {
            Console.WriteLine("Invalid student or course.");
            return false;
        }

        if (!_enrollments.ContainsKey(course))
            _enrollments[course] = new List<TStudent>();

        // Rule 1: Capacity
        if (_enrollments[course].Count >= course.MaxCapacity)
        {
            Console.WriteLine("Enrollment failed: Course at full capacity.");
            return false;
        }

        // Rule 2: Already enrolled
        if (_enrollments[course].Any(s => s.StudentId == student.StudentId))
        {
            Console.WriteLine("Enrollment failed: Student already enrolled.");
            return false;
        }

        // Rule 3: Prerequisite (if course is LabCourse)
        if (course is LabCourse lab)
        {
            if (student.Semester < lab.RequiredSemester)
            {
                Console.WriteLine("Enrollment failed: Semester prerequisite not met.");
                return false;
            }
        }

        _enrollments[course].Add(student);
        Console.WriteLine($"Enrollment successful: {student.Name} -> {course.Title}");
        return true;
    }

    public IReadOnlyList<TStudent> GetEnrolledStudents(TCourse course)
    {
        if (_enrollments.ContainsKey(course))
            return _enrollments[course].AsReadOnly();

        return new List<TStudent>().AsReadOnly();
    }

    public IEnumerable<TCourse> GetStudentCourses(TStudent student)
    {
        return _enrollments
            .Where(kv => kv.Value.Any(s => s.StudentId == student.StudentId))
            .Select(kv => kv.Key);
    }

    public int CalculateStudentWorkload(TStudent student)
    {
        return GetStudentCourses(student).Sum(c => c.Credits);
    }

    // Helper method for gradebook
    public bool IsEnrolled(TStudent student, TCourse course)
    {
        return _enrollments.ContainsKey(course) &&
               _enrollments[course].Any(s => s.StudentId == student.StudentId);
    }
}

// ================= SPECIALIZED CLASSES =================
public class EngineeringStudent : IStudent
{
    public int StudentId { get; set; }
    public string Name { get; set; }
    public int Semester { get; set; }
    public string Specialization { get; set; }
}

public class LabCourse : ICourse
{
    public string CourseCode { get; set; }
    public string Title { get; set; }
    public int MaxCapacity { get; set; }
    public int Credits { get; set; }
    public string LabEquipment { get; set; }
    public int RequiredSemester { get; set; }
}

// ================= GENERIC GRADEBOOK =================
public class GradeBook<TStudent, TCourse>
    where TStudent : IStudent
    where TCourse : ICourse
{
    private Dictionary<(TStudent, TCourse), double> _grades = new();
    private EnrollmentSystem<TStudent, TCourse> _enrollment;

    public GradeBook(EnrollmentSystem<TStudent, TCourse> enrollment)
    {
        _enrollment = enrollment;
    }

    public void AddGrade(TStudent student, TCourse course, double grade)
    {
        if (grade < 0 || grade > 100)
            throw new ArgumentException("Grade must be between 0 and 100.");

        if (!_enrollment.IsEnrolled(student, course))
            throw new InvalidOperationException("Student not enrolled in course.");

        _grades[(student, course)] = grade;
    }

    public double? CalculateGPA(TStudent student)
    {
        var studentGrades = _grades
            .Where(g => g.Key.Item1.StudentId == student.StudentId)
            .ToList();

        if (!studentGrades.Any())
            return null;

        double totalWeighted = 0;
        int totalCredits = 0;

        foreach (var g in studentGrades)
        {
            var course = g.Key.Item2;
            totalWeighted += g.Value * course.Credits;
            totalCredits += course.Credits;
        }

        return totalWeighted / totalCredits;
    }

    public (TStudent student, double grade)? GetTopStudent(TCourse course)
    {
        var courseGrades = _grades
            .Where(g => g.Key.Item2.CourseCode == course.CourseCode)
            .ToList();

        if (!courseGrades.Any())
            return null;

        var top = courseGrades.OrderByDescending(g => g.Value).First();
        return (top.Key.Item1, top.Value);
    }
}

// ================= TEST SIMULATION =================
class Program
{
    static void Main()
    {
        var enrollment = new EnrollmentSystem<EngineeringStudent, LabCourse>();
        var gradeBook = new GradeBook<EngineeringStudent, LabCourse>(enrollment);

        // Students
        var s1 = new EngineeringStudent { StudentId = 1, Name = "Anu", Semester = 3, Specialization = "CSE" };
        var s2 = new EngineeringStudent { StudentId = 2, Name = "Rahul", Semester = 5, Specialization = "ECE" };
        var s3 = new EngineeringStudent { StudentId = 3, Name = "Simran", Semester = 2, Specialization = "CSE" };

        // Courses
        var c1 = new LabCourse
        {
            CourseCode = "CSL101",
            Title = "Programming Lab",
            Credits = 4,
            MaxCapacity = 2,
            LabEquipment = "Computers",
            RequiredSemester = 3
        };

        var c2 = new LabCourse
        {
            CourseCode = "CSL201",
            Title = "Advanced Lab",
            Credits = 5,
            MaxCapacity = 2,
            LabEquipment = "Robotics",
            RequiredSemester = 5
        };

        // ===== Enrollment =====
        enrollment.EnrollStudent(s1, c1); // success
        enrollment.EnrollStudent(s2, c1); // success
        enrollment.EnrollStudent(s3, c1); // fail (capacity)
        enrollment.EnrollStudent(s3, c2); // fail (prerequisite)
        enrollment.EnrollStudent(s2, c2); // success

        // ===== Grades =====
        gradeBook.AddGrade(s1, c1, 85);
        gradeBook.AddGrade(s2, c1, 90);
        gradeBook.AddGrade(s2, c2, 88);

        // ===== GPA =====
        Console.WriteLine("\nGPA:");
        Console.WriteLine($"Anu: {gradeBook.CalculateGPA(s1)}");
        Console.WriteLine($"Rahul: {gradeBook.CalculateGPA(s2)}");

        // ===== Top student =====
        var top = gradeBook.GetTopStudent(c1);
        if (top != null)
            Console.WriteLine($"\nTop in {c1.Title}: {top?.student.Name} - {top?.grade}");

        // ===== Workload =====
        Console.WriteLine("\nWorkload:");
        Console.WriteLine($"Rahul Credits: {enrollment.CalculateStudentWorkload(s2)}");
    }
}
