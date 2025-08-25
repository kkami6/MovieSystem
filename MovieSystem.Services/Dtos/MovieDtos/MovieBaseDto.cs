using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Dtos.MovieDtos
{
    public class MovieBaseDto
    {
        public string Title { get; set; } = default!;

        public string Genre { get; set; }

        public int ReleaseYear { get; set; }
        
        public int DirectorId { get; set; }
    }
}
