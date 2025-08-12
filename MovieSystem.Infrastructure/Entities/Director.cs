using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Entities
{
    public class Director(int movieId, string title, string genre, DateTime releaseDate)
    {
        public int MovieId { get; set; } = movieId;

        public string Title { get; set; } = title;

        public string Genre { get; set; } = genre;

        public DateTime ReleaseDate { get; set; } = releaseDate;

        public int MovieID { get; set;} = movieId;
    }
}
