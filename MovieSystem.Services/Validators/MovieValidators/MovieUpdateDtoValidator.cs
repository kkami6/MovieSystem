using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MovieSystem.Services.Dtos.MovieDtos;

namespace MovieSystem.Services.Validators.MovieValidators
{
    public class MovieUpdateDtoValidator: AbstractValidator<MovieUpdateDto>
    {
        public MovieUpdateDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.ReleaseYear).InclusiveBetween(1900, DateTime.Now.Year);
            RuleFor(x => x.DirectorId).GreaterThan(0);
        }
    }
}
