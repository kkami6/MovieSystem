using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Repositories
{
    public interface IMovieRepository
    {
        Task<Movie> Create(Movie model);

        Task<Movie?> Get(int id);

        Task<List<Movie>> GetAll();

        Task<Movie> Update(Movie model);

        Task Delete(int id);

        Task<List<MovieRatingDetails>> GetRatedByUser(int userId);

        Task<List<MovieWithAverageRating>> GetByDirectorWithAverageRating(int directorId);

        Task<List<MovieWithAverageRating>> GetTopRated(int top);
    }
}
