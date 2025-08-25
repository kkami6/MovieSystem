using AutoMapper;
using MovieSystem.Core.Models;
using MovieSystem.Services.Dtos;
using MovieSystem.Services.Dtos.DirectorDtos;
using MovieSystem.Services.Dtos.MovieDtos;
using MovieSystem.Services.Dtos.RatingDtos;
using MovieSystem.Services.Dtos.UserDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieSystem.Services.Profiles
{
    public class MappingProfile: Profile
    {
        public MappingProfile() 
        {
            // User mappings
            CreateMap<User, UserGetDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            // Director mappings
            CreateMap<Director, DirectorGetDto>();
            CreateMap<DirectorCreateDto, Director>();
            CreateMap<DirectorUpdateDto, Director>();

            //// Movie mappings
            CreateMap<Movie, MovieGetDto>();
            CreateMap<MovieCreateDto, Movie>();
            CreateMap<MovieUpdateDto, Movie>();

            //// Rating mappings
            CreateMap<Rating, RatingGetDto>();
            CreateMap<RatingCreateDto, Rating>();
            CreateMap<RatingUpdateDto, Rating>();

            //// Mappings for extra models
            CreateMap<MovieWithAverageRating, MovieWithAverageRatingDto>();
            CreateMap<MovieRatingDetails, MovieRatingDetailsDto>();
        }
        
    }
}
