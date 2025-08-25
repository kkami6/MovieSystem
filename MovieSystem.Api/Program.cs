
using FluentValidation;
using MovieSystem.Core.Repositories;
using MovieSystem.Infrastructure.Repositories;
using MovieSystem.Services.Dtos.DirectorDtos;
using MovieSystem.Services.Dtos.MovieDtos;
using MovieSystem.Services.Dtos.RatingDtos;
using MovieSystem.Services.Dtos.UserDtos;
using MovieSystem.Services.Interfaces;
using MovieSystem.Services.Profiles;
using MovieSystem.Services.Services;
using MovieSystem.Services.Validators.DirectorValidators;
using MovieSystem.Services.Validators.MovieValidators;
using MovieSystem.Services.Validators.RatingValidators;
using MovieSystem.Services.Validators.UserValidators;
using Microsoft.EntityFrameworkCore;
using MovieSystem.Infrastructure.Entities;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MovieSystem.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<MovieSystemContext>(options => options.UseMySql(connectionString,new MySqlServerVersion(new Version(8, 0, 33))));

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Repositories
            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IDirectorRepository, DirectorRepository>();
            builder.Services.AddScoped<IMovieRepository, MovieRepository>();
            builder.Services.AddScoped<IRatingRepository, RatingRepository>();


            //AutoMapper
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IMovieService, MovieService>();
            builder.Services.AddScoped<IDirectorService, DirectorService>();
            builder.Services.AddScoped<IRatingService, RatingService>();

            //Validators
            builder.Services.AddScoped<IValidator<UserCreateDto>, UserCreateDtoValidator>();
            builder.Services.AddScoped<IValidator<UserUpdateDto>, UserUpdateDtoValidator>();

            builder.Services.AddScoped<IValidator<DirectorCreateDto>, DirectorCreateDtoValidator>();
            builder.Services.AddScoped<IValidator<DirectorUpdateDto>, DirectorUpdateDtoValidator>();

            builder.Services.AddScoped<IValidator<MovieCreateDto>, MovieCreateDtoValidator>();
            builder.Services.AddScoped<IValidator<MovieUpdateDto>, MovieUpdateDtoValidator>();

            builder.Services.AddScoped<IValidator<RatingCreateDto>, RatingCreateDtoValidator>();
            builder.Services.AddScoped<IValidator<RatingUpdateDto>, RatingUpdateDtoValidator>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<MovieSystem.Api.Middlewares.ExceptionHandlingMiddleware>();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();          
        }
    }
}
