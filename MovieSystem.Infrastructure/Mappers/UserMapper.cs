using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Mappers
{
    public static class UserMapper
    {
        public static User ToDomainModel(this Entities.UserEntity entity) => new(
        entity.Id,
        entity.FirstName,
        entity.LastName,
        entity.Email,
        entity.DateOfBirth
    );

        public static List<User> ToDomainModelList(this IEnumerable<Entities.UserEntity> entities)
            => entities.Select(ToDomainModel).ToList();

        public static Entities.UserEntity ToEntity(this User domainModel) => new(
            domainModel.Id,
            domainModel.FirstName,
            domainModel.LastName,
            domainModel.Email,
            domainModel.DateOfBirth
        );
    }
}
