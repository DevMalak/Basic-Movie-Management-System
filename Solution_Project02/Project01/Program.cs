using project.Models;
using project.Services;

namespace project
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MovieService service = new MovieService();
            bool running = true;

            while (running)
            {
                Console.Clear();

                Console.WriteLine("===== Movie Management System =====");
                Console.WriteLine("1. View Movies");
                Console.WriteLine("2. Add Movie");
                Console.WriteLine("3. Search Movie");
                Console.WriteLine("4. Delete Movie");
                Console.WriteLine("5. Exit");
                Console.WriteLine("6. Update Movie");
                Console.Write("Choose option: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Clear();
                        service.ViewMovies();
                        Pause();
                        break;

                    case "2":
                        Console.Clear();

                        int id;

                        // loop until unique ID
                        while (true)
                        {
                            Console.Write("Enter ID: ");
                            id = ReadInt();

                            if (service.IdExists(id))
                            {
                                Console.WriteLine("ID already exists, try another one.");
                            }
                            else
                            {
                                break;
                            }
                        }

                        Console.Write("Enter Title: ");
                        string title = Console.ReadLine();

                        Console.Write("Enter Genre: ");
                        string genre = Console.ReadLine();

                        Console.Write("Enter Year: ");
                        int year = ReadInt();

                        Movie newMovie = new Movie(id, title, genre, year);
                        service.AddMovie(newMovie);

                        Pause();
                        break;

                    case "3":
                        Console.Clear();

                        Console.Write("Enter movie title: ");
                        string search = Console.ReadLine();

                        service.SearchMovie(search);
                        Pause();
                        break;

                    case "4":
                        Console.Clear();

                        Console.Write("Enter movie ID: ");
                        int deleteId = ReadInt();

                        service.DeleteMovie(deleteId);
                        Pause();
                        break;

                    case "5":
                        Console.WriteLine("Goodbye ");
                        running = false;
                        break;

                    case "6":
                        Console.Clear();

                        Console.Write("Enter movie ID to update: ");
                        int updateId = ReadInt();

                        service.UpdateMovie(updateId);

                        Pause();
                        break;

                    default:
                        Console.WriteLine("Invalid option!");
                        Pause();
                        break;
                }
            }
        }

        static int ReadInt()
        {
            int value;
            while (!int.TryParse(Console.ReadLine(), out value))
            {
                Console.Write("Invalid input. Enter a number: ");
            }
            return value;
        }

        static void Pause()
        {
            Console.WriteLine("\nPress any key to continue...");
            Console.ReadKey();
        }
    }
}