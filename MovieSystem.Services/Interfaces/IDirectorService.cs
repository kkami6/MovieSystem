using MovieSystem.Services.Dtos.DirectorDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Interfaces
{
    public interface IDirectorService
    {
        Task<List<DirectorGetDto>> GetAll();
        Task<DirectorGetDto?> GetById(int id);
        Task<DirectorGetDto> Create(DirectorCreateDto dto);
        Task<DirectorGetDto> Update(DirectorUpdateDto dto);
        Task Delete(int id);
    }
}
