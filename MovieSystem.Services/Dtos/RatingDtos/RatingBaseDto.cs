using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Dtos.RatingDtos
{
    public class RatingBaseDto
    {
        public int UserId { get; set; }
        
        public int MovieId { get; set; }
        
        public int Value { get; set; }
    }
}
