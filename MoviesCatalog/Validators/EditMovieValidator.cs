using FluentValidation;
using MoviesCatalog.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesCatalog.Validators
{
    public class EditMovieValidator : AbstractValidator<EditViewModel>
    {
        public EditMovieValidator()
        {
            RuleFor(x => x.ImageFile)
               .Must(Validation.IsValidFileExtension).When(x => x.ImageFile != null)
               .WithMessage("This photo extension is not allowed!")
               .Must(Validation.IsValidFileSize).When(x => x.ImageFile != null)
               .WithMessage("Maximum allowed file size is 10 MB.");

            RuleFor(x => x.Description)
                .NotEmpty()
                .WithMessage("Movie description cannot be empty")
                .MaximumLength(1000)
                .WithMessage("Movie description must contain maximum 1000 characters");

            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Movie title cannot be empty")
                .MaximumLength(100)
                .WithMessage("Movie title must contain maximum 100 characters");

            RuleFor(x => x.Year)
                .NotEmpty()
                .WithMessage("Movie year cannot be empty");
        }
    }
}
