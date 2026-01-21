namespace MyConsoleApp
{
    public interface IFilm
    {
        string? Title { get; set; }
        string? Director { get; set; }
    }
    public interface IFilmLibrary
    {
    }
    public class Film : IFilm
    {
        public string? Title { get; set; }
        public string? Director { get; set; }
        public int Year { get; set; }
    }

    public class FilmLibrary : IFilmLibrary
    {
        private readonly List<IFilm> _films = [];

        public void AddFilm(IFilm film) => _films.Add(film);

        public void RemoveFilm(string title)
        {
            var film = _films.FirstOrDefault(f => f.Title == title);
            if (film != null) _films.Remove(film);
        }

        public List<IFilm> GetFilms() => _films;

        public List<IFilm> SearchFilms(string query)
        {
            return _films.Where(f =>
                (f.Title?.Contains(query, StringComparison.OrdinalIgnoreCase) ?? false) ||
                (f.Director?.Contains(query, StringComparison.OrdinalIgnoreCase) ?? false)
            ).ToList();
        }

        public int GetTotalFilmCount() => _films.Count;
    }

    public class MovieList
    {
        public static void Main()
        {
            FilmLibrary fm = new();
            bool running = true;

            Console.WriteLine("--- Film Library Management System ---");

            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Add a Film");
                Console.WriteLine("2. List All Films");
                Console.WriteLine("3. Search Films");
                Console.WriteLine("4. Remove a Film");
                Console.WriteLine("5. Exit");
                Console.Write("\nSelection: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter Title: ");
                        string? title = Console.ReadLine();
                        Console.Write("Enter Director: ");
                        string? director = Console.ReadLine();
                        Console.Write("Enter Year: ");
                        int.TryParse(Console.ReadLine(), out int year);

                        fm.AddFilm(new Film { Title = title, Director = director, Year = year });
                        Console.WriteLine("Film added successfully!");
                        break;

                    case "2":
                        var allFilms = fm.GetFilms();
                        Console.WriteLine("\n--- Current Library ---");
                        if (allFilms.Count == 0) Console.WriteLine("Library is empty.");
                        foreach (var f in allFilms) Console.WriteLine($"- {f.Title} ({f.Director})");
                        break;

                    case "3":
                        Console.Write("Enter search query (Title or Director): ");
                        string query = Console.ReadLine() ?? "";
                        var results = fm.SearchFilms(query);
                        Console.WriteLine("\n--- Search Results ---");
                        foreach (var f in results) Console.WriteLine($"- {f.Title} by {f.Director}");
                        break;

                    case "4":
                        Console.Write("Enter the exact title of the film to remove: ");
                        string? toRemove = Console.ReadLine();
                        if (toRemove != null) fm.RemoveFilm(toRemove);
                        Console.WriteLine("Process complete.");
                        break;

                    case "5":
                        running = false;
                        break;

                    default:
                        Console.WriteLine("Invalid selection, please try again.");
                        break;
                }
            }
        }
    }
}