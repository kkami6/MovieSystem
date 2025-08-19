using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class Rating(int id, int userId, int movieId, int score)
    {
        public int Id { get; set; } = id;

        public int UserId { get; set; } = userId;

        public int MovieId { get; set; } = movieId;

        public int Score { get; set; } = score;

        public User? User { get; set; }
        public Movie? Movie { get; set; }
    }
}
