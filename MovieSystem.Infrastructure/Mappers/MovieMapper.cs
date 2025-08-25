using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Mappers
{
    public static class MovieMapper
    {
        public static Movie ToDomainModel(this Entities.MovieEntity entity)
        {
            return new Movie
            {
                Id = entity.Id,
                Title = entity.Title,
                Genre = entity.Genre,
                ReleaseYear = entity.ReleaseYear,
                DirectorId = entity.DirectorId,
            };
        }


        public static List<Movie> ToDomainModelList(this IEnumerable<Entities.MovieEntity> entities)
            => entities.Select(ToDomainModel).ToList();

        public static Entities.MovieEntity ToEntity(this Movie domainModel) => new(
            domainModel.Id,
            domainModel.Title,
            domainModel.Genre,
            domainModel.ReleaseYear,
            domainModel.DirectorId
        );
    }
}
