using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Repositories
{
    public interface IRatingRepository
    {
        Task<Rating> Create(Rating model);

        Task<Rating?> Get(int id);

        Task<List<Rating>> GetAll();

        Task<Rating> Update(Rating model);

        Task Delete(int id);

        Task<List<Rating>> GetByUser(int userId);

        Task<List<Rating>> GetByMovie(int movieId);
    }
}
