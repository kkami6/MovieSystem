using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MovieSystem.Services.Dtos.RatingDtos;

namespace MovieSystem.Services.Validators.RatingValidators
{
    public class RatingUpdateDtoValidator: AbstractValidator<RatingUpdateDto>
    {
        public RatingUpdateDtoValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0);
            RuleFor(x => x.UserId).GreaterThan(0);
            RuleFor(x => x.MovieId).GreaterThan(0);
            RuleFor(x => x.Score).InclusiveBetween(1, 10);
        }
    }
}
