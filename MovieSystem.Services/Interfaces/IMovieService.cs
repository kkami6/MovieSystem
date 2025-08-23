using MovieSystem.Services.Dtos.MovieDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Interfaces
{
    public interface IMovieService
    {
        Task<List<MovieGetDto>> GetAll();
        Task<MovieGetDto?> GetById(int id);
        Task<MovieGetDto> Create(MovieCreateDto dto);
        Task<MovieGetDto> Update(MovieUpdateDto dto);
        Task Delete(int id);

        // Extra queries
        Task<List<MovieRatingDetailsDto>> GetRatedByUser(int userId);
        Task<List<MovieWithAverageRatingDto>> GetByDirectorWithAverageRating(int directorId);
        Task<List<MovieWithAverageRatingDto>> GetTopRated(int top);
    }
}
