using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Entities
{
    public class Rating(int ratingId, int score)
    {
        public int RatingId { get; set; } = ratingId;
                        
        public int Score { get; set; } = score;
    }
}
