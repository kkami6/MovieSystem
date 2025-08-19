using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Mappers
{
    public static class DirectorMapper
    {
        public static Director ToDomainModel(this Entities.DirectorEntity entity) => new(
        entity.Id,
        entity.Name,
        entity.BirthDate,
        entity.Nationality
    );

        public static List<Director> ToDomainModelList(this IEnumerable<Entities.DirectorEntity> entities)
            => entities.Select(ToDomainModel).ToList();

        public static Entities.DirectorEntity ToEntity(this Director domainModel) => new(
            domainModel.Id,
            domainModel.Name,
            domainModel.BirthDate,
            domainModel.Nationality
        );
    }
}
