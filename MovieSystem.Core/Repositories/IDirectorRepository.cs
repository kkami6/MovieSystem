using MovieSystem.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Core.Repositories
{
    internal interface IDirectorRepository
    {
        Task<Director> Create(Director model);

        Task<Director?> Get(int id);

        Task<List<Director>> GetAll();

        Task<Director> Update(Director model);

        Task Delete(int id);
    }
}
