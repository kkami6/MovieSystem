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
    public class DirectorRepository : IDirectorRepository
    {
        private readonly MovieSystemContext _context;

        public DirectorRepository(MovieSystemContext context)
        {
            _context = context;
        }

        public async Task<Director> Create(Director model)
        {
            var entity = model.ToEntity();
            await _context.Directors.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity.ToDomainModel();
        }

        public async Task<Director?> Get(int id)
        {
            var entity = await _context.Directors.SingleOrDefaultAsync(x => x.Id == id);
            return entity?.ToDomainModel();
        }

        public async Task<List<Director>> GetAll()
        {
            var entities = await _context.Directors.ToListAsync();
            return entities.ToDomainModelList();
        }

        public async Task<Director> Update(Director model)
        {
            var entity = await _context.Directors.SingleAsync(x => x.Id == model.Id);
            var updated = model.ToEntity();

            entity.Name = updated.Name;
            entity.BirthDate = updated.BirthDate;
            entity.Nationality = updated.Nationality;

            await _context.SaveChangesAsync();
            return entity.ToDomainModel();
        }

        public async Task Delete(int id)
        {
            var entity = await _context.Directors.SingleAsync(x => x.Id == id);
            _context.Directors.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
