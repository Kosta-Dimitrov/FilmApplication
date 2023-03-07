using FilmApplication.Models.Films;
using FluentValidation;
using System; 

namespace FilmApplication.Validations
{
    public class FilmValidator:AbstractValidator<FilmDto>
    {
        public FilmValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Name).Length(3, 35);
            RuleFor(x => x.Description).NotEmpty().WithMessage("Please add a description");
            RuleFor(x => x.Description).Length(5, 250).WithMessage("Description should be between 5 and 250 symbols");
            RuleFor(x => x.Year).InclusiveBetween(1899, DateTime.UtcNow.Year);
            RuleFor(x => x.Duration).InclusiveBetween(1, 1234);
        }
    }
}
