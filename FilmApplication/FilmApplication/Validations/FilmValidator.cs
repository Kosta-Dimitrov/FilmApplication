using System;
using FilmApplication.Models.Films;
using FluentValidation;
using static FilmApplication.Validations.Constants.Film;


namespace FilmApplication.Validations
{
    public class FilmValidator : AbstractValidator<FilmDto>
    {
        public FilmValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(NameMinLength, NameMaxLength);
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please add a description");
            RuleFor(x => x.Description).Length(MinDescriptionLength, MaxDescriptionLength).WithMessage($"Description should be between { MinDescriptionLength } and { MaxDescriptionLength } symbols");
            RuleFor(x => x.Year).InclusiveBetween(MinYear, DateTime.UtcNow.Year);
            RuleFor(x => x.Duration).InclusiveBetween(1, MaxDuration);
        }
    }
}
