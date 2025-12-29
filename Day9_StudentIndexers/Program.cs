// Create a Student with public props. of rno, name, private field of address, indexers for books he have...

using System;

namespace Day9_StudentIndexers
{
    class Student(int rno, string name, string address, params string[] initialBooks)
    {
        // if set is removed, create constructor with parameters and to work default constructors should also be called
        public int Rno { get; set; } = rno;
        public string? Name { get; set; } = name;

        private string? Address { get; set; } = address;

        private string[] books = initialBooks;

        public string this[int index]
        {
            get
            {
                return (index >= 0 && index < books.Length) ? books[index] : "Invalid book index";
            }
            set
            {
                if (index >= 0 && index < books.Length)
                {
                    books[index] = value;
                }
                else
                {
                    Console.WriteLine("Cannot set book: Index is out of range.");
                }
            }
        }

        // Public method to display the private address (optional)
        public void DisplayAddress()
        {
            Console.WriteLine($"Address: {Address}");
        }
    }
    class StudentIndexer
    {
        static void Main(string[] args)
        {
            Student student1 = new Student(
                1,
                "Alice Smith",
                "123 Main St, City, Country",
                "Calculus Textbook",
                "Physics Handbook",
                "History of the World"
            );

            Console.WriteLine($"Student Name: {student1.Name}");
            student1.DisplayAddress();

            // Access books using the indexer (read access)
            Console.WriteLine($"Book 1: {student1[0]}");
            Console.WriteLine($"Book 2: {student1[1]}");
            Console.WriteLine($"Book 3: {student1[2]}");
 
            // Modify a book using the indexer (write access)
            student1[1] = "Advanced Physics Handbook";
            Console.WriteLine($"Updated Book 2: {student1[1]}");
        }
    }
}