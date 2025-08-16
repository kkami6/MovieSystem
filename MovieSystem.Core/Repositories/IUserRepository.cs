using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Repositories
{
    public interface IUserRepository
    {
        Task<User> Create(User model);

        Task<User?> Get(int id);

        Task<List<User>> GetAll();

        Task<User> Update(User model);

        Task Delete(int id);
    }
}
