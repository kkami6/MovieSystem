using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class Rating(int ratingId, int userId, int movieId, int score)
    {
        public int RatingId { get; set; } = ratingId;
        
        public int UserId { get; set; } = userId;
        
        public int MovieId { get; set; } = movieId;
        
        public int Score { get; set; } = score;
    }
}
