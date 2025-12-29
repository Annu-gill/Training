using ExamSchedule.Data;

namespace ExamSchedule
{
    public class Program
    {
        static void Main(string[] args)
        {
            var localStudents = DataBank.GetStudents();

            foreach (var student in localStudents)
            {
                System.Console.WriteLine($"{student.Id} - {student.Name}");
            }
            
            var localSections = DataSection.GetSections();

            foreach (var section in localSections)
            {
                System.Console.WriteLine($"{section.Id} - {section.Name}");
            }
        }
    }
}
