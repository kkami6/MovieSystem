using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Entities
{
    public class Movie(int movieId, string title, string genre, DateOnly releaseDate, int directorId)
    {
        public int MovieId { get; set; } = movieId;

        public string Title { get; set; } = title;
        
        public string Genre { get; set; } = genre;
        
        public DateOnly ReleaseDate { get; set; } = releaseDate;
        
        public int DirectorId { get; set; } = directorId;

    }
}
