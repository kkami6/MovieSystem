using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Mappers
{
    public static class RatingMapper
    {
        public static Rating ToDomainModel(this Entities.RatingEntity entity) => new(
        entity.Id,
        entity.UserId,
        entity.MovieId,
        entity.Score
    );

        public static List<Rating> ToDomainModelList(this IEnumerable<Entities.RatingEntity> entities)
            => entities.Select(ToDomainModel).ToList();

        public static Entities.RatingEntity ToEntity(this Rating domainModel) => new(
            domainModel.Id,
            domainModel.UserId,
            domainModel.MovieId,
            domainModel.Score
        );
    }
}
