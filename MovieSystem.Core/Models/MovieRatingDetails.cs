using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class MovieRatingDetails(Movie movie, int rating)
    {
        public Movie Movie { get; } = movie;
        public int Rating { get; } = rating;
    }
}
