using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagement
{
    // Book class
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public int PublicationYear { get; set; }

        public override string ToString()
        {
            return $"{Id}. {Title} by {Author} ({PublicationYear})";
        }
    }

    // Utility class
    public class LibraryUtility
    {
        private Dictionary<int, Book> books = new Dictionary<int, Book>();
        private int idCounter = 1;

        // Add book with auto-incremented ID
        public void AddBook(string title, string author, string genre, int year)
        {
            Book book = new Book
            {
                Id = idCounter++,
                Title = title,
                Author = author,
                Genre = genre,
                PublicationYear = year
            };

            books.Add(book.Id, book);
        }

        // Group books by genre alphabetically
        public SortedDictionary<string, List<Book>> GroupBooksByGenre()
        {
            SortedDictionary<string, List<Book>> groupedBooks =
                new SortedDictionary<string, List<Book>>();

            foreach (var book in books.Values)
            {
                if (!groupedBooks.ContainsKey(book.Genre))
                {
                    groupedBooks[book.Genre] = new List<Book>();
                }
                groupedBooks[book.Genre].Add(book);
            }

            return groupedBooks;
        }

        // Get books by author
        public List<Book> GetBooksByAuthor(string author)
        {
            return books.Values
                        .Where(b => b.Author.Equals(author, StringComparison.OrdinalIgnoreCase))
                        .ToList();
        }

        // Total books count
        public int GetTotalBooksCount()
        {
            return books.Count;
        }
    }

    // Program class
    public class Program
    {
        public static void Main()
        {
            LibraryUtility library = new LibraryUtility();

            // 1. Add books
            library.AddBook("The Silent Patient", "Alex Michaelides", "Mystery", 2019);
            library.AddBook("1984", "George Orwell", "Fiction", 1949);
            library.AddBook("Sapiens", "Yuval Noah Harari", "Non-Fiction", 2011);
            library.AddBook("Animal Farm", "George Orwell", "Fiction", 1945);

            // 2. Display books grouped by genre
            Console.WriteLine("Books Grouped by Genre:\n");
            var grouped = library.GroupBooksByGenre();

            foreach (var genre in grouped)
            {
                Console.WriteLine($"Genre: {genre.Key}");
                foreach (var book in genre.Value)
                {
                    Console.WriteLine("  " + book);
                }
                Console.WriteLine();
            }

            // 3. Search books by author
            Console.WriteLine("Books by George Orwell:\n");
            var authorBooks = library.GetBooksByAuthor("George Orwell");

            foreach (var book in authorBooks)
            {
                Console.WriteLine(book);
            }

            // 4. Show statistics
            Console.WriteLine("\nLibrary Statistics:");
            Console.WriteLine($"Total Books: {library.GetTotalBooksCount()}");

            foreach (var genre in grouped)
            {
                Console.WriteLine($"{genre.Key}: {genre.Value.Count} book(s)");
            }
        }
    }
}
