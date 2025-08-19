using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Entities
{
    public class RatingEntity(int id, int userId, int movieId, int score)
    {
        public int Id { get; set; } = id;
        
        public int UserId { get; set; } = userId;
        
        public int MovieId { get; set; } = movieId;
        
        public int Score { get; set; } = score;

        public UserEntity? User { get; set; }
        
        public MovieEntity? Movie { get; set; }
    }
}
