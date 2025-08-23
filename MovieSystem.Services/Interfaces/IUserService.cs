using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieSystem.Services.Dtos.UserDtos;

namespace MovieSystem.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<UserGetDto>> GetAll();
        Task<UserGetDto?> GetById(int id);
        Task<UserGetDto> Create(UserCreateDto dto);
        Task<UserGetDto> Update(UserUpdateDto dto);
        Task Delete(int id);
    }
}
