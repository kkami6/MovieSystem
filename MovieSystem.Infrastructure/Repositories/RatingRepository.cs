using Microsoft.EntityFrameworkCore;
using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using MovieSystem.Infrastructure.Entities;
using MovieSystem.Infrastructure.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Infrastructure.Repositories
{
    public class RatingRepository() : IRatingRepository
    {
        private readonly MovieSystemContext context;

        public async Task<Rating> Create(Rating model)
        {
            var entity = model.ToEntity();
            await context.Ratings.AddAsync(entity);
            await context.SaveChangesAsync();
            return entity.ToDomainModel();
        }

        public async Task<Rating?> Get(int id)
        {
            var entity = await context.Ratings.SingleOrDefaultAsync(x => x.Id == id);
            return entity?.ToDomainModel();
        }

        public async Task<List<Rating>> GetAll()
        {
            var entities = await context.Ratings.ToListAsync();
            return entities.ToDomainModelList();
        }

        public async Task<Rating> Update(Rating model)
        {
            var entity = await context.Ratings.SingleAsync(x => x.Id == model.Id);
            var updated = model.ToEntity();

            entity.UserId = updated.UserId;
            entity.MovieId = updated.MovieId;
            entity.Score = updated.Score;

            await context.SaveChangesAsync();
            return entity.ToDomainModel();
        }

        public async Task Delete(int id)
        {
            var entity = await context.Ratings.SingleAsync(x => x.Id == id);
            context.Ratings.Remove(entity);
            await context.SaveChangesAsync();
        }

        public async Task<List<Rating>> GetByUser(int userId)
        {
            var ratings = await context.Ratings
                .Where(r => r.UserId == userId)
                .ToListAsync();

            return ratings.ToDomainModelList();
        }

        public async Task<List<Rating>> GetByMovie(int movieId)
        {
            var ratings = await context.Ratings
                .Where(r => r.MovieId == movieId)
                .ToListAsync();

            return ratings.ToDomainModelList();
        }
    }
}
