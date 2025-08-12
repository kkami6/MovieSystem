using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Models
{
    public class Director(int directorId, string name, DateOnly birthDate, string nationality)
    {
        public int DirectorId { get; set; } = directorId;

        public string Name { get; set; } = name;
        
        public DateOnly BirthDate { get; set; } = birthDate;
        
        public string Nationality { get; set; } = nationality;
    }
}
