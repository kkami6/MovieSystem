using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Entities
{
    public class User (int userId, string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        public int UserId { get; set; } = userId;

        public string FirstName { get; set; } = firstName;

        public string LastName { get; set; } = lastName;

        public string Email { get; set; } = email;

        public DateTime DateOfBirth { get; set; } = dateOfBirth;

        public List<Rating> Ratings { get; set; } = new List<Rating>();
    }
}
