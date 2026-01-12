
// using System;
// using System.IO; // used for StringWriter(stores XML in memory)
// using System.Collections.Generic;   // Required for collections
// using System.Xml.Serialization; // provides XmlSerializer, the core class for XML serialization

// // all properties and fields converted to XML serialization, not the functions
// public class Student
// {
//     // public properties, so they are converted to XML elements
//     public int Id { get; set; }
//     public string Name { get; set; }
//     public List<string> Subjects {get; set;}
//     // public List<Course> Courses {get; set;}
//     public Student()
//     {
//         Subjects=new List<string>();
//         Courses=new List<Course>();
//     } // parameterless constructor
//     // Required because XmlSerializer creates objects internally during serialization/deserialization
// }
// // Complex type used inside collection
// public class Course
// {
//     public string CourseName { get; set; }
//     public int Credits { get; set; }
//     public Course() { } // Required
// }
// class Program
// {
//     static void Main()  // entry point of program
//     {
//         Student student = new Student // Creates a Student object
//         {
//             Id = 101,
//             Name = "Annu",
//             Subjects = new List<string> { "Maths", "Physics", "Computer Science" },
//             Courses = new List<Course>
//             {
//                 new Course { CourseName = "C#", Credits = 4 },
//                 new Course { CourseName = "SQL", Credits = 3 }
//             }
//         };

//         ///<summary>
//         /// XmlSerializer converts objects → XML
//         /// typeof(Student) tells the serializer which class structure to follow
//         /// Without this, the serializer doesn’t know how to map properties to XML tags
//         /// </summary>

//         XmlSerializer serializer = new XmlSerializer(typeof(Student));

//         ///<summary>
//         /// StringWriter stores XML in memory as text
//         /// Serialize(writer, student)
//         /// Reads student object
//         /// Converts public properties into XML
//         /// Writes XML into writer
//         /// writer.ToString() retrieves the XML as a string
//         /// Console.WriteLine(xmlData) prints the XML output
//         /// </summary>
//         using (StringWriter writer = new StringWriter())
//         {
//             serializer.Serialize(writer, student);
//             string xmlData = writer.ToString();
//             Console.WriteLine(xmlData);
//         }
//     }
// }


// // write code with a student object and properties as id, name, marks and marks need to be stored in list instead of array
// // Convert marks to list instead of array

// using System;
// using System.IO;
// using System.Collections.Generic;
// using System.Xml.Serialization;

// public class Student
// {
//     public int Id { get; set; }
//     public string Name { get; set; }
//     // Marks stored in array
//     // public int[] Marks { get; set; }
//     // Marks stored in List instead of array
//     public List<int> Marks { get; set; }

//     // Parameterless constructor (required)
//     public Student()
//     {
//         // Marks = new int[0];  // array
//         Marks = new List<int>();  // for list
//     }
// }
// class Program
// {
//     static void Main()
//     {
//         Student student = new Student
//         {
//             Id = 1,
//             Name = "Annu",
//             // Marks = new int[] { 85, 90, 78, 92 }  // for array
//             Marks = new List<int> { 85, 90, 78, 92 }  // for list
//         };

//         XmlSerializer serializer = new XmlSerializer(typeof(Student));

//         using (StringWriter writer = new StringWriter())
//         {
//             serializer.Serialize(writer, student);
//             Console.WriteLine(writer.ToString());
//         }
//     }
// }


// // dictionary inside object and when u try to call it, it's not.

// Q.
// take object data and serialize it in json
// take json data deserialize it

using System;
// using System.Collections.Generic;
// using System.Text.Json;

// public class Student
// {
//     public int Id { get; set; }
//     public string? Name { get; set; }
//     public List<int>? Marks { get; set; }
// }
// class Program
// {
//     static void Main()
//     {
//         // OBJECT → JSON (Serialization)
//         Student student = new Student
//         {
//             Id = 1,
//             Name = "Annu",
//             Marks = new List<int> { 85, 90, 88 }
//         };

//         string jsonData = JsonSerializer.Serialize(student);
//         Console.WriteLine("Serialized JSON:");
//         Console.WriteLine(jsonData);

//         // JSON → OBJECT (Deserialization)
//         Student deserializedStudent =
//             JsonSerializer.Deserialize<Student>(jsonData);

//         Console.WriteLine("\nDeserialized Object:");
//         Console.WriteLine($"Id: {deserializedStudent.Id}");
//         Console.WriteLine($"Name: {deserializedStudent.Name}");
//         Console.WriteLine("Marks:");
//         foreach (var mark in deserializedStudent.Marks)
//         {
//             Console.WriteLine(mark);
//         }
//     }
// }




