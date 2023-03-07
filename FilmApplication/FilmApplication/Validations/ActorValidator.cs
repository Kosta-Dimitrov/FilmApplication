using FilmApplication.Models.Actors;
using FluentValidation;
using System;

namespace FilmApplication.Validations
{
    public class ActorValidator:AbstractValidator<ActorDto>
    {
        public ActorValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x=>x.dateOfBirth).NotNull();
            RuleFor(x => x.Name).Length(3,18).WithMessage("Name should be between 3 and 18 symbols");
        }
    }
}
