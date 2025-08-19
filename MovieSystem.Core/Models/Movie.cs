using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class Movie(int id, string title, string genre, DateTime releaseDate, int directorId)
    {
        public int Id { get; set; } = id;

        public string Title { get; set; } = title;

        public string Genre { get; set; } = genre;

        public DateTime ReleaseDate { get; set; } = releaseDate;

        public int DirectorId { get; set; } = directorId;

        public Director? Director { get; set; }

        public List<Rating> Ratings { get; set; } = new List<Rating>();

        public double? AverageRating => Ratings.Count == 0 ? null : Ratings.Average(r => r.Score);
    }
}
