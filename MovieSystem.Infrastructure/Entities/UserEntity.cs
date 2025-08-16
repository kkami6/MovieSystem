using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Entities
{
    public class UserEntity (int id, string firstName, string lastName, string email, DateTime dateOfBirth)
    {
        public int Id { get; set; } = id;
        public string FirstName { get; set; } = firstName;
        public string LastName { get; set; } = lastName;
        public string Email { get; set; } = email;
        public DateTime DateOfBirth { get; set; } = dateOfBirth;

        public List<RatingEntity> Ratings { get; set; } = new List<RatingEntity>();
    }
}
