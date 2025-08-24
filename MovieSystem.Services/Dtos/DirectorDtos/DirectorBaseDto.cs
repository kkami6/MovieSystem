using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Dtos.DirectorDtos
{
    public class DirectorBaseDto
    {
        public string Name { get; set; } = default!;

        public DateTime? BirthDate { get; set; }

        public string? Nationality { get; set; }
    }
}
