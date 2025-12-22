// // // See https://aka.ms/new-console-template for more information
// // Console.WriteLine("Hello, World!");

// class Program
// {
//     public static void Main(String[] args)
//     {
//         Day01.Run();
//         Day02.Run();
//         Day03.Run();
//     }
// }


// using System;

// class Student
// {
//     // Fields
//     private int rollNo;
//     private string nameStudent;
//     private string courseOpted;

//     // Set methods to set the value
//     public void SetRoll(int rollNo)
//     {
//         this.rollNo = rollNo;
//     }

//     public void SetName(string nameStudent)
//     {
//         this.nameStudent = nameStudent;
//     }

//     public void SetCourse(string courseOpted)
//     {
//         this.courseOpted = courseOpted;
//     }

//     // get methods to get the value
//     public int GetRoll()
//     {
//         return rollNo;
//     }

//     public string GetName()
//     {
//         return nameStudent;
//     }

//     public string GetCourse()
//     {
//         return courseOpted;
//     }
// }
// class Program
// {
//     static void Main(string[] args)
//     {
//         Student s = new Student();

//         Console.Write("Enter Roll Number: ");
//         s.SetRoll(Convert.ToInt32(Console.ReadLine()));

//         Console.Write("Enter Student Name: ");
//         s.SetName(Console.ReadLine());

//         Console.Write("Enter Course Opted: ");
//         s.SetCourse(Console.ReadLine());

//         Console.WriteLine("\nStudent Details:");
//         Console.WriteLine("Roll No: " + s.GetRoll());
//         Console.WriteLine("Name: " + s.GetName());
//         Console.WriteLine("Course: " + s.GetCourse());

//         Console.ReadLine();
//     }
// }

// create region inside the class and constructor also

// using System;

// public class Employee
// {
//     public int id;
//     public String Name;
//     public String Designation;
    
// }

// public class Competition
// {
//     public int Id;
//     public String CompetitionName;
//     public String level;
//     public int Score;

// }

// public class CompetitionResult
// {
//    public Competition Competition;
//    public Employee Winner;    
//    public int Rank;

//    public string Comments;
// }

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         CompetitionResult[] competitionResults=new CompetitionResult[5];
//         competitionResults[0] = new CompetitionResult();
//         competitionResults[0].Competition=new Competition()
//         {
//             Id = 1,
//             CompetitionName = "Coding Contest",
//             level = "Intermediate",
//             Score = 85
//         };
//         competitionResults[0].Winner=new Employee()
//         {
//             id = 101,
//             Name = "Annu",
//             Designation = "Software Trainee"
            
//         };
//         competitionResults[0].Rank=1;
//         competitionResults[0].Comments="Winner";



//         Console.WriteLine("---- Competition Result ----");
//         Console.WriteLine("Employee ID      : " + competitionResults[0].Winner.id);
//         Console.WriteLine("Employee Name    : " + competitionResults[0].Winner.Name);
//         Console.WriteLine("Designation      : " + competitionResults[0].Winner.Designation);
//         Console.WriteLine("Competition Name : " + competitionResults[0].Competition.CompetitionName);
//         Console.WriteLine("Level            : " + competitionResults[0].Competition.level);
//         Console.WriteLine("Score            : " + competitionResults[0].Competition.Score);
//         Console.WriteLine("Rank             : " + competitionResults[0].Rank);
//         Console.WriteLine("Comments         : " + competitionResults[0].Comments);
//     }
// }



// using System;

// public class HighSchool
// {
//     public int id;
//     public String Name;
//     public String Degree;
    
// }

// public class UnderGraduate
// {
//     public int Id;
//     public String Name;
//     public String Degree;
//     public int Score;

// }

// public class PostGraduate
// {
//     public int Id;
//     public String Name;
//     public String Degree;
//     public int Score;

// }

// public class CompetitionResult
// {
//    public Competition Competition;
//    public Employee Winner;    
//    public int Rank;

//    public string Comments;
// }

// public class Program
// {
//     public static void Main(string[] args)
//     {
//         CompetitionResult[] competitionResults=new CompetitionResult[5];
//         competitionResults[0] = new CompetitionResult();
//         competitionResults[0].Competition=new Competition()
//         {
//             Id = 1,
//             CompetitionName = "Coding Contest",
//             level = "Intermediate",
//             Score = 85
//         };
//         competitionResults[0].Winner=new Employee()
//         {
//             id = 101,
//             Name = "Annu",
//             Designation = "Software Trainee"
            
//         };
//         competitionResults[0].Rank=1;
//         competitionResults[0].Comments="Winner";



//         Console.WriteLine("---- Competition Result ----");
//         Console.WriteLine("Employee ID      : " + competitionResults[0].Winner.id);
//         Console.WriteLine("Employee Name    : " + competitionResults[0].Winner.Name);
//         Console.WriteLine("Designation      : " + competitionResults[0].Winner.Designation);
//         Console.WriteLine("Competition Name : " + competitionResults[0].Competition.CompetitionName);
//         Console.WriteLine("Level            : " + competitionResults[0].Competition.level);
//         Console.WriteLine("Score            : " + competitionResults[0].Competition.Score);
//         Console.WriteLine("Rank             : " + competitionResults[0].Rank);
//         Console.WriteLine("Comments         : " + competitionResults[0].Comments);
//     }
// }



// using System;
// public class Program
// {
    
//     public static void Main(string[] args)
//     {
//         Program program = new Program();


        
//         Person person=new Person();

//         Person person = new Person() { Id=1, age=20, Name="Arul" };
//         program.GetDetails(person);

//         Man man = new Man() { Id = 10, Name = "Kumar", age = 24 , Playing="Football"};

//         Woman woman = new Woman() { Id = 10, Name = "Kumari", age = 24 , PlayMange="Rugby and Home"};


//         Person personw = woman;

//         Person childObject = new Child() { age = 1, Id = 100, Name = "Anki", WatchingCartoon = "Chota Beem" };

//         program.GetDetails(person);

//         program.GetDetails(childObject);




//     }

//     public string GetManDetails (Man input)
//     {
//         return $" Id = { input.Id}  Name = {input.Name}";
//     }

//     public string GetWomanDetails(Woman input)
//     {
//         return $" Id = {input.Id}  Name = {input.Name}";
//     }

//     public string GetDetails(Person person )
//     {

//         string result=string.Empty;
//         if(person is Man)
//         {
//             Man man=(Man) person;
//             result=$"Id = {man Id} name = {man.name} Playing = { man.Playing}";
//         }
//         if (person is Woman)
//         {
//             Woman woman=(Woman) person;
//             result=$"Id = {woman Id} name = {woman.name} Playing = {woman.Playing}";
//         }
//         // return $" Id = {person.Id}  Name = {person.Name} playing = {person.Playing}";
//     }



// }



// using System;
// using System.Security.Cryptography.X509Certificates;
// public class Program{
//     public static void Main(String[] args)
//     {
//         class
//     }

// }