using MovieSystem.Services.Dtos.RatingDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Interfaces
{
    public interface IRatingService
    {
        Task<List<RatingGetDto>> GetAll();
        Task<RatingGetDto?> GetById(int id);
        Task<RatingGetDto> Create(RatingCreateDto dto);
        Task<RatingGetDto> Update(RatingUpdateDto dto);
        Task Delete(int id);

        Task<List<RatingGetDto>> GetByUser(int userId);
        Task<List<RatingGetDto>> GetByMovie(int movieId);
    }
}
