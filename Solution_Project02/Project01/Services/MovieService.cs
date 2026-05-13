using project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Services
{
    public class MovieService
    {
        private List<Movie> movies;

        public MovieService()
        {
            movies = new List<Movie>();

            movies.Add(new Movie(1, "Frozen", "Animation", 2013));
            movies.Add(new Movie(2, "Avatar", "Sci-Fi", 2009));
            movies.Add(new Movie(3, "Titanic", "Romance", 1997));
            movies.Add(new Movie(4, "Batman", "Action", 2022));
            movies.Add(new Movie(5, "Toy Story", "Comedy", 1995));
        }

        // COLORS
        private void Success(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        private void Error(string msg)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(msg);
            Console.ResetColor();
        }

        // VIEW
        public void ViewMovies()
        {
            if (movies.Count == 0)
            {
                Error("No movies available.");
                return;
            }

            foreach (Movie movie in movies)
            {
                Console.WriteLine($"ID: {movie.Id} | Title: {movie.Title} | Genre: {movie.Genre} | Year: {movie.Year}");
                Console.WriteLine("----------------------------");
            }
        }

        // ADD
        public void AddMovie(Movie movie)
        {
            if (movies.Any(m => m.Id == movie.Id))
            {
                Error("ID already exists! Movie not added.");
                return;
            }

            movies.Add(movie);
            Success("Movie added successfully!");
        }

        // SEARCH
        public void SearchMovie(string title)
        {
            bool found = false;

            foreach (var m in movies)
            {
                if (m.Title.ToLower().Contains(title.ToLower()))
                {
                    Console.WriteLine($"ID: {m.Id} | Title: {m.Title} | Genre: {m.Genre} | Year: {m.Year}");
                    Console.WriteLine("----------------------------");
                    found = true;
                }
            }

            if (!found)
            {
                Error("No movie found with this title.");
            }
        }

        // DELETE
        public void DeleteMovie(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                Error("Movie not found.");
                return;
            }

            Console.WriteLine($"Are you sure you want to delete '{movie.Title}'? (y/n): ");
            string confirm = Console.ReadLine();

            if (confirm.ToLower() != "y")
            {
                Error("Cancelled.");
                return;
            }

            movies.Remove(movie);
            Success("Movie deleted successfully!");
        }

        // ⭐ UPDATE MOVIE (NEW)
        public void UpdateMovie(int id)
        {
            var movie = movies.FirstOrDefault(m => m.Id == id);

            if (movie == null)
            {
                Error("Movie not found.");
                return;
            }

            Console.Write("Enter new Title: ");
            movie.Title = Console.ReadLine();

            Console.Write("Enter new Genre: ");
            movie.Genre = Console.ReadLine();

            Console.Write("Enter new Year: ");
            movie.Year = int.Parse(Console.ReadLine());

            Success("Movie updated successfully!");
        }

        // ID CHECK
        public bool IdExists(int id)
        {
            return movies.Any(m => m.Id == id);
        }
    }
}