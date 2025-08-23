using AutoMapper;
using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using MovieSystem.Services.Dtos.DirectorDtos;
using MovieSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Services
{
    public class DirectorService: IDirectorService
    {
        private readonly IDirectorRepository _repository;
        private readonly IMapper _mapper;

        public DirectorService(IDirectorRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<DirectorGetDto>> GetAll()
        {
            var directors = await _repository.GetAll();
            return _mapper.Map<List<DirectorGetDto>>(directors);
        }

        public async Task<DirectorGetDto?> GetById(int id)
        {
            var director = await _repository.Get(id);
            return _mapper.Map<DirectorGetDto?>(director);
        }

        public async Task<DirectorGetDto> Create(DirectorCreateDto dto)
        {
            var director = _mapper.Map<Director>(dto);
            var created = await _repository.Create(director);
            return _mapper.Map<DirectorGetDto>(created);
        }

        public async Task<DirectorGetDto> Update(DirectorUpdateDto dto)
        {
            var director = _mapper.Map<Director>(dto);
            var updated = await _repository.Update(director);
            return _mapper.Map<DirectorGetDto>(updated);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
