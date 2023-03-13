using FluentValidation;
using FilmApplication.Models.Actors;

using static FilmApplication.Validations.Constants.Actor;

namespace FilmApplication.Validations
{
    public class ActorValidator : AbstractValidator<ActorDto>
    {
        public ActorValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.dateOfBirth).NotNull();
            RuleFor(x => x.Name).Length(NameMinLength, NameMaxLength).WithMessage($"Name should be between { NameMinLength } and { NameMaxLength } symbols");
        }
    }
}
