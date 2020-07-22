using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using FluentValidation;
using MoviesCatalog.Models;
using MoviesCatalog.ViewModels;

namespace MoviesCatalog.Validators
{
    public class MovieValidator : AbstractValidator<MovieViewModel>
    {
        public MovieValidator()
        {
            RuleFor(x => x.ImageFile)
                .Must(Validation.IsValidFileExtension)
                .WithMessage("This photo extension is not allowed!")
                .NotEmpty()
                .WithMessage("Movie poster cannot be empty")
                .Must(Validation.IsValidFileSize)
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
