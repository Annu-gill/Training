using System;

namespace XamXpert
{
    // Exam Interface
    interface Exam
    {
        double calculateScore(); // Abstract method to calculate score

        // Static method to evaluate result based on percentage
        static string evaluateResult(double percentage)
        {
            if (percentage >= 85)
                return "Merit";
            else if (percentage >= 60)
                return "Pass";
            else
                return "Fail";
        }
    }

    // OnlineTest class implementing Exam interface
    class OnlineTest : Exam
    {
        // Attributes
        public string studentName { get; set; }
        public int totalQuestions { get; set; }
        public int correctAnswers { get; set; }
        public int wrongAnswers { get; set; }
        public string questionType { get; set; }

        // Constructor
        public OnlineTest(string studentName, string questionType, int totalQuestions, int correctAnswers, int wrongAnswers)
        {
            this.studentName = studentName;
            this.questionType = questionType;
            this.totalQuestions = totalQuestions;
            this.correctAnswers = correctAnswers;
            this.wrongAnswers = wrongAnswers;
        }

        // Implement calculateScore method
        public double calculateScore()
        {
            double marksPerQuestion = 0;

            if (questionType == "MCQ")
                marksPerQuestion = 2;
            else if (questionType == "Coding")
                marksPerQuestion = 5;
            else
                throw new Exception("Invalid Question Type");

            double totalScore = (correctAnswers * marksPerQuestion) - (wrongAnswers * (marksPerQuestion * 0.10));
            double percentage = (totalScore / (totalQuestions * marksPerQuestion)) * 100;

            return Math.Round(percentage, 1); // Round to 1 decimal place
        }
    }

    // UserInterface class with Main method
    class UserInterface
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Enter Exam Details:");

            Console.Write("Student Name: ");
            string studentName = Console.ReadLine();

            Console.Write("Question Type (MCQ/Coding): ");
            string questionType = Console.ReadLine();

            Console.Write("Total Questions: ");
            int totalQuestions = int.Parse(Console.ReadLine());

            Console.Write("Correct Answers: ");
            int correctAnswers = int.Parse(Console.ReadLine());

            Console.Write("Wrong Answers: ");
            int wrongAnswers = int.Parse(Console.ReadLine());

            // Initialize OnlineTest object
            OnlineTest test = new OnlineTest(studentName, questionType, totalQuestions, correctAnswers, wrongAnswers);

            // Calculate percentage
            double totalScore = test.calculateScore();

            // Evaluate result using static method from interface
            string result = Exam.evaluateResult(totalScore);

            // Display output
            Console.WriteLine($"\nExam Summary:");
            Console.WriteLine($"{questionType} Test: {studentName}, Total Score: {totalScore.ToString("F1")}, Result: {result}");
        }
    }
}