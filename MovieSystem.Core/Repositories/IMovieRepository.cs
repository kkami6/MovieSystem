using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Repositories
{
    internal interface IMovieRepository
    {
        Task<Movie> Create(Movie model);

        Task<Movie> Get(int id);

        Task<List<Movie>> GetAll();
        
        Task<Movie> Update(Movie model);
        
        Task Delete(int id);

        Task<List<(Movie Movie, double AvgRating)>> GetMoviesByDirectorWithAvgRating(int directorId);

        Task<List<(Movie Movie, double AvgRating)>> GetTopRatedMovies(int topN);
    }
}
