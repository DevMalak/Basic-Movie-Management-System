using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace project.Models
{
    public class Movie
    {
        // Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Year { get; set; }

        // Constructor
        public Movie(int id, string title, string genre, int year)
        {
            Id = id;
            Title = title;
            Genre = genre;
            Year = year;
        }
    }
}