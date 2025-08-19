using MovieSystem.Core.Repositories;
using MovieSystem.Core.Models;
using MovieSystem.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSystem.Infrastructure.Mappers;

namespace MovieSystem.Infrastructure.Repositories
{
    public class UserRepository(MovieSystemContext context) : IUserRepository
    {
        public async Task<User> Create(User model)
        {
            var entity = model.ToEntity();
            await context.Users.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.ToDomainModel();
        }

        public async Task<User?> Get(int id)
        {
            var entity = await context.Users.SingleOrDefaultAsync(x => x.Id == id);
            return entity?.ToDomainModel();
        }

        public async Task<List<User>> GetAll()
        {
            var entities = await context.Users.ToListAsync();
            return entities.ToDomainModelList();
        }

        public async Task<User> Update(User model)
        {
            var entity = await context.Users.SingleAsync(x => x.Id == model.Id);
            var updated = model.ToEntity();

            entity.FirstName = updated.FirstName;
            entity.LastName = updated.LastName;
            entity.Email = updated.Email;
            entity.DateOfBirth = updated.DateOfBirth;

            await context.SaveChangesAsync();
            return entity.ToDomainModel();
        }

        public async Task Delete(int id)
        {
            var entity = await context.Users.SingleAsync(x => x.Id == id);
            context.Users.Remove(entity);
            await context.SaveChangesAsync();
        }
    }
}
