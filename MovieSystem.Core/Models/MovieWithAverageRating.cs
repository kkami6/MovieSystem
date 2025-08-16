using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class MovieWithAverageRating(Movie movie, double? averageRating)
    {
        public Movie Movie { get; } = movie;
        public double? AverageRating { get; } = averageRating;
    }
}
