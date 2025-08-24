using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
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
        private readonly IValidator<UserCreateDto> _createValidator;
        private readonly IValidator<UserUpdateDto> _updateValidator;

        public UserService(
            IUserRepository repository,
            IMapper mapper,
            IValidator<UserCreateDto> createValidator,
            IValidator<UserUpdateDto> updateValidator)
        {
            _repository = repository;
            _mapper = mapper;
            _createValidator = createValidator;
            _updateValidator = updateValidator;
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
            var validation = await _createValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new FluentValidation.ValidationException(validation.Errors);

            var user = _mapper.Map<User>(dto);
            var created = await _repository.Create(user);
            return _mapper.Map<UserGetDto>(created);
        }

        public async Task<UserGetDto> Update(UserUpdateDto dto)
        {
            var validation = await _updateValidator.ValidateAsync(dto);
            if (!validation.IsValid)
                throw new FluentValidation.ValidationException(validation.Errors);

            var user = _mapper.Map<User>(dto);
            var updated = await _repository.Update(user);
            return _mapper.Map<UserGetDto>(updated);
        }

        public async Task Delete(int id) => await _repository.Delete(id);
    }
}
