using AutoMapper;
using FluentValidation;
using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using MovieSystem.Services.Dtos.RatingDtos;
using MovieSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Services
{
    public class RatingService: IRatingService
    {
        private readonly IRatingRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<RatingCreateDto> _createValidator;
        private readonly IValidator<RatingUpdateDto> _updateValidator;

        public RatingService(
            IRatingRepository repository,
            IMapper mapper,
            IValidator<RatingCreateDto> createValidator,
            IValidator<RatingUpdateDto> updateValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
        }

        public async Task<List<RatingGetDto>> GetAll()
        {
            var ratings = await _repository.GetAll();
            return _mapper.Map<List<RatingGetDto>>(ratings);
        }

        public async Task<RatingGetDto?> GetById(int id)
        {
            var rating = await _repository.Get(id);
            return _mapper.Map<RatingGetDto?>(rating);
        }

        public async Task<RatingGetDto> Create(RatingCreateDto dto)
        {
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new FluentValidation.ValidationException(validation.Errors);

            var rating = _mapper.Map<Rating>(dto);
            var created = await _repository.Create(rating);
            return _mapper.Map<RatingGetDto>(created);
        }

        public async Task<RatingGetDto> Update(RatingUpdateDto dto)
        {
            var validation = await _updateValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new FluentValidation.ValidationException(validation.Errors);

            var rating = _mapper.Map<Rating>(dto);
            var updated = await _repository.Update(rating);
            return _mapper.Map<RatingGetDto>(updated);
        }

        public async Task Delete(int id) => await _repository.Delete(id);

        public async Task<List<RatingGetDto>> GetByUser(int userId)
        {
            var results = await _repository.GetByUser(userId);
            return _mapper.Map<List<RatingGetDto>>(results);
        }

        public async Task<List<RatingGetDto>> GetByMovie(int movieId)
        {
            var results = await _repository.GetByMovie(movieId);
            return _mapper.Map<List<RatingGetDto>>(results);
        }
    }
}
