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
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieSystemContext _context;

        public MovieRepository(MovieSystemContext context)
        {
            _context = context;
        }

        public async Task<Movie> Create(Movie model)
        {
            var entity = model.ToEntity();
            await _context.Movies.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.ToDomainModel();
        }

        public async Task<Movie?> Get(int id)
        {
            var entity = await _context.Movies.SingleOrDefaultAsync(x => x.Id == id);
            return entity?.ToDomainModel();
        }

        public async Task<List<Movie>> GetAll()
        {
            var entities = await _context.Movies.ToListAsync();
            return entities.ToDomainModelList();
        }

        public async Task<Movie> Update(Movie model)
        {
            var entity = await _context.Movies.SingleAsync(x => x.Id == model.Id);
            var updated = model.ToEntity();

            entity.Title = updated.Title;
            entity.Genre = updated.Genre;
            entity.ReleaseYear = updated.ReleaseYear;
            entity.DirectorId = updated.DirectorId;

            await _context.SaveChangesAsync();
            return entity.ToDomainModel();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Movies.SingleAsync(x => x.Id == id);
            _context.Movies.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<List<MovieRatingDetails>> GetRatedByUser(int userId)
        {
            var result = await _context.Ratings
                .Include(r => r.Movie)
                .Where(r => r.UserId == userId)
                .ToListAsync();

            return result
                .Select(r => new MovieRatingDetails(r.Movie.ToDomainModel(), r.Score))
                .ToList();
        }

        public async Task<List<MovieWithAverageRating>> GetByDirectorWithAverageRating(int directorId)
        {
            var movies = await _context.Movies
                .Include(m => m.Ratings)
                .Where(m => m.DirectorId == directorId)
                .ToListAsync();

            return movies
                .Select(m => new MovieWithAverageRating(
                    m.ToDomainModel(),
                    m.Ratings.Any() ? m.Ratings.Average(r => r.Score) : 0))
                .ToList();
        }

        public async Task<List<MovieWithAverageRating>> GetTopRated(int top)
        {
            var movies = await _context.Movies
                .Include(m => m.Ratings)
                .ToListAsync();

            return movies
                .Select(m => new MovieWithAverageRating(
                    m.ToDomainModel(),
                    m.Ratings.Any() ? m.Ratings.Average(r => r.Score) : 0))
                .OrderByDescending(m => m.AverageRating)
                .Take(top)
                .ToList();
        }
    }
}
