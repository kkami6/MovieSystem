using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public DateTime DateOfBirth { get; set; }

        public List<Rating> Ratings { get; set; }

        public List<Movie> RatedMovies => Ratings
            .Where(r => r.Movie is not null)
            .Select(r => r.Movie!)
            .ToList();
    }
}
