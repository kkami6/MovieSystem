using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class Movie
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Genre { get; set; }

        public int ReleaseYear { get; set; }

        public int DirectorId { get; set; }

        public Director? Director { get; set; }

        public List<Rating> Ratings { get; set; }

        public double? AverageRating => Ratings.Count == 0 ? null : Ratings.Average(r => r.Score);
    }
}
