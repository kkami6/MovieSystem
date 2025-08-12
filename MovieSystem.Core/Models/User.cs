using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class User(int userId, string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        public int UserId { get; set; } = userId;

        public string FirstName { get; set; } = firstName;

        public string LastName { get; set; } = lastName;

        public string Email { get; set; } = email;

        public DateTime DateOfBirth { get; set; } = dateOfBirth;
    }
}
