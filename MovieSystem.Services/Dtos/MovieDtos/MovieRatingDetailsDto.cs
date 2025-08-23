using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Dtos.MovieDtos
{
    public class MovieRatingDetailsDto
    {
        public MovieGetDto Movie { get; set; } = default!;
        
        public int Rating { get; set; }
    }
}
