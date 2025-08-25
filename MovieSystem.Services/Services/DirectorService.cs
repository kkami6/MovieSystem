using AutoMapper;
using FluentValidation;
using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using MovieSystem.Services.Dtos.DirectorDtos;
using MovieSystem.Services.Interfaces;

namespace MovieSystem.Services.Services
{
    public class DirectorService : IDirectorService
    {
        private readonly IDirectorRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<DirectorCreateDto> _createValidator;
        private readonly IValidator<DirectorUpdateDto> _updateValidator;

        public DirectorService(
            IDirectorRepository repository,
            IMapper mapper,
            IValidator<DirectorCreateDto> createValidator,
            IValidator<DirectorUpdateDto> updateValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
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
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new FluentValidation.ValidationException(validation.Errors);

            try
            {
                var res = _mapper.Map<Director>(dto);
            }
            catch (Exception)
            {

                throw;
            }

            var director = _mapper.Map<Director>(dto);
            var created = await _repository.Create(director);
            return _mapper.Map<DirectorGetDto>(created);
        }

        public async Task<DirectorGetDto> Update(DirectorUpdateDto dto)
        {
            var validation = await _updateValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new FluentValidation.ValidationException(validation.Errors);

            var director = _mapper.Map<Director>(dto);
            var updated = await _repository.Update(director);
            return _mapper.Map<DirectorGetDto>(updated);
        }

        public async Task Delete(int id) => await _repository.Delete(id);
    }
}
