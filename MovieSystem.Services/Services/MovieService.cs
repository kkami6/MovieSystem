using AutoMapper;
using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using MovieSystem.Services.Dtos.MovieDtos;
using MovieSystem.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Services
{
    public class MovieService: IMovieService
    {
        private readonly IMovieRepository _repository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<MovieGetDto>> GetAll()
        {
            var movies = await _repository.GetAll();
            return _mapper.Map<List<MovieGetDto>>(movies);
        }

        public async Task<MovieGetDto?> GetById(int id)
        {
            var movie = await _repository.Get(id);
            return _mapper.Map<MovieGetDto?>(movie);
        }

        public async Task<MovieGetDto> Create(MovieCreateDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);
            var created = await _repository.Create(movie);
            return _mapper.Map<MovieGetDto>(created);
        }

        public async Task<MovieGetDto> Update(MovieUpdateDto dto)
        {
            var movie = _mapper.Map<Movie>(dto);
            var updated = await _repository.Update(movie);
            return _mapper.Map<MovieGetDto>(updated);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }

        // Extra queries
        public async Task<List<MovieRatingDetailsDto>> GetRatedByUser(int userId)
        {
            var results = await _repository.GetRatedByUser(userId);
            return _mapper.Map<List<MovieRatingDetailsDto>>(results);
        }

        public async Task<List<MovieWithAverageRatingDto>> GetByDirectorWithAverageRating(int directorId)
        {
            var results = await _repository.GetByDirectorWithAverageRating(directorId);
            return _mapper.Map<List<MovieWithAverageRatingDto>>(results);
        }

        public async Task<List<MovieWithAverageRatingDto>> GetTopRated(int top)
        {
            var results = await _repository.GetTopRated(top);
            return _mapper.Map<List<MovieWithAverageRatingDto>>(results);
        }
    }
}
