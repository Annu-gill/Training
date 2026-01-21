// Question 2: 

using System;
using System.Collections.Generic;
using System.Linq;

namespace Day18_Practice
{
    public class Movie
    {
        // Properties
        public string Title { get; set; }
        public string Artist { get; set; }
        public string Genre { get; set; }
        public int Ratings { get; set; }
    }

    public class MovieOperations
    {
        // Provided list
        public static List<Movie> MovieList = new List<Movie>();

        // Add movie details
        public static void AddMovie(string movieDetails)
        {
            string[] data = movieDetails.Split(',');

            Movie movie = new Movie
            {
                Title = data[0],
                Artist = data[1],
                Genre = data[2],
                Ratings = int.Parse(data[3])
            };

            MovieList.Add(movie);
        }

        // View movies by genre
        public static List<Movie> ViewMoviesByGenre(string genre)
        {
            return MovieList
                .Where(m => m.Genre.Equals(genre, StringComparison.OrdinalIgnoreCase))
                .ToList();
        }

        // View movies by ratings (ascending)
        public static List<Movie> ViewMoviesByRatings()
        {
            return MovieList
                .OrderBy(m => m.Ratings)
                .ToList();
        }
    }
}
