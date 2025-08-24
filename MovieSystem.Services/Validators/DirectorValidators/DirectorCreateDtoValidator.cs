using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MovieSystem.Services.Dtos.DirectorDtos;

namespace MovieSystem.Services.Validators.DirectorValidators
{
    public class DirectorCreateDtoValidator : AbstractValidator<DirectorCreateDto>
    {
        public DirectorCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().MaximumLength(50);
            RuleFor(x => x.BirthDate).LessThan(DateTime.Today)
                                       .WithMessage("Date of birth must be in the past.");
            RuleFor(x => x.Nationality).MaximumLength(50);
        }
    }
}
