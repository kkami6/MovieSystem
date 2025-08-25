using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace MovieSystem.Infrastructure.Entities
{
    public class DirectorEntity(int id, string name, DateTime? birthDate, string? nationality)
    {
        public int Id { get; set; } = id;
        
        public string Name { get; set; } = name;
        
        public DateTime? BirthDate { get; set; } = birthDate;
        
        public string? Nationality { get; set; } = nationality;

        public List<MovieEntity> Movies { get; set; } = new List<MovieEntity>();
    }
}
