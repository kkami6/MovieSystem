using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class User(int id, string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        public int Id { get; set; } = id;

        public string FirstName { get; set; } = firstName;

        public string LastName { get; set; } = lastName;

        public string Email { get; set; } = email;

        public DateTime DateOfBirth { get; set; } = dateOfBirth;

        public List<Rating> Ratings { get; set; } = new List<Rating>();

        public List<Movie> RatedMovies => Ratings
            .Where(r => r.Movie is not null)
            .Select(r => r.Movie!)
            .ToList();
    }
}
