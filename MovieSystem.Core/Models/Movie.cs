using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class Movie(int movieId, string title, string genre, DateTime releaseDate)
    {
        public int MovieId { get; set; } = movieId;

        public string Title { get; set; } = title;

        public string Genre { get; set; } = genre;

        public DateTime ReleaseDate { get; set; } = releaseDate;
    }
}
