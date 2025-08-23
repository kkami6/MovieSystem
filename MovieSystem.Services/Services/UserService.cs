using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MovieSystem.Core.Models;
using MovieSystem.Core.Repositories;
using MovieSystem.Services.Dtos;
using MovieSystem.Services.Dtos.UserDtos;
using MovieSystem.Services.Interfaces;


namespace MovieSystem.Services.Services
{
    public class UserService: IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<UserGetDto>> GetAll()
        {
            var users = await _repository.GetAll();
            return _mapper.Map<List<UserGetDto>>(users);
        }

        public async Task<UserGetDto?> GetById(int id)
        {
            var user = await _repository.Get(id);
            return _mapper.Map<UserGetDto?>(user);
        }

        public async Task<UserGetDto> Create(UserCreateDto dto)
        {
            var user = _mapper.Map<User>(dto);
            var created = await _repository.Create(user);
            return _mapper.Map<UserGetDto>(created);
        }

        public async Task<UserGetDto> Update(UserUpdateDto dto)
        {
            var user = _mapper.Map<User>(dto);
            var updated = await _repository.Update(user);
            return _mapper.Map<UserGetDto>(updated);
        }

        public async Task Delete(int id)
        {
            await _repository.Delete(id);
        }
    }
}
