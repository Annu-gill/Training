// // semester name converted to enum type and subject  names also enum type
// // like make 2 semesters and 5 subjects in each semester
// // using array store it take vallue and  convert them in label value

// namespace Day15_Enum
// {
//     public enum Semester
//     {
//         Semester1=1,
//         Semester2=2
//     }
//     public enum SubjectsSem1
//     {
//         Physics=1,
//         Maths=2,
//         Mechanical=3,
//         Electronics=4,
//         Python=5
//     }
//     public enum SubjectsSem2
//     {
//         Cpp=1,
//         DiscreteMaths=2,
//         DSA=3,
//         SoftSkills=4,
//         Devops=5
//     }
//     public class SemesterSubjectEnum
//     {
//         public static void Main()
//         {

//             int[,] semesterSub = new int[2, 5];

//             // Semester 1 subjects
//             semesterSub[0, 0] = (int)SubjectsSem1.Physics;
//             semesterSub[0, 1] = (int)SubjectsSem1.Maths;
//             semesterSub[0, 2] = (int)SubjectsSem1.Mechanical;
//             semesterSub[0, 3] = (int)SubjectsSem1.Electronics;
//             semesterSub[0, 4] = (int)SubjectsSem1.Python;

//             // Semester 2 subjects
//             semesterSub[1, 0] = (int)SubjectsSem2.Cpp;
//             semesterSub[1, 1] = (int)SubjectsSem2.DiscreteMaths;
//             semesterSub[1, 2] = (int)SubjectsSem2.DSA;
//             semesterSub[1, 3] = (int)SubjectsSem2.SoftSkills;
//             semesterSub[1, 4] = (int)SubjectsSem2.Devops;

//             // Display label (name) and value
//             Console.WriteLine("Semester 1 Subjects:");
//             for (int i = 0; i < 5; i++)
//             {
//                 SubjectsSem1 subject =
//                     (SubjectsSem1)semesterSub[0, i];
//                 Console.WriteLine($"Label: {subject}, Value: {(int)subject}");
//             }

//             Console.WriteLine("\nSemester 2 Subjects:");
//             for (int i = 0; i < 5; i++)
//             {
//                 SubjectsSem2 subject =
//                     (SubjectsSem2)semesterSub[1, i];
//                 Console.WriteLine($"Label: {subject}, Value: {(int)subject}");
//             }
        
//         }
//     }
// }




// namespace Day15_Enum
// {
//     public enum Semesters
//     {
//         Semester1 = 1,
//         Semester2 = 2
//     }

//     public enum Subjects
//     {
//         English = 1,
//         Maths = 2,
//         Physics = 3,
//         Python = 4,
//         SoftSkills = 5
//     }

//     public class SemesterEnum
//     {
//         public static void Main()
//         {
//             int[,] semsub = new int[2, 6];
//             semsub[0, 0] = (int)Semesters.Semester1;
//             semsub[0, 1] = (int)Subjects.Maths;
//             semsub[0, 2] = (int)Subjects.Python;
//             semsub[0, 3] = (int)Subjects.Physics;
//             semsub[0, 4] = (int)Subjects.SoftSkills;
//             semsub[0, 5] = (int)Subjects.English;
//             semsub[1, 0] = (int)Semesters.Semester2;
//             semsub[1, 1] = (int)Subjects.Maths;
//             semsub[1, 2] = (int)Subjects.Python;
//             semsub[1, 3] = (int)Subjects.Physics;
//             semsub[1, 4] = (int)Subjects.SoftSkills;
//             semsub[1, 5] = (int)Subjects.English;

//             for (int i = 0; i < semsub.GetLength(0); i++)
//             {
//                 Console.WriteLine($"Semester: {(Semesters)semsub[i, 0]}");
//                 Console.Write("Subjects: ");

//                 for (int j = 1; j < semsub.GetLength(1); j++)
//                 {
//                     Console.Write($"{(Subjects)semsub[i, j]} ");
//                 }

//                 Console.WriteLine("\n");
//             }
//         }
//     }
// }



