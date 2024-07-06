using BookArchive.Application.Features.BookFeatures.Commands.CreateBook;
using BookArchive.Application.Features.BookFeatures.Commands.UpdateBook;
using BookArchive.Domain.DTOs;
using FluentValidation;

namespace BookArchive.Application.Validations
{
    public class BookValidator : AbstractValidator<BookDTO>
    {
        public BookValidator()
        {
            RuleFor(b => b.Name)
                .NotEmpty().MinimumLength(4)
                .WithMessage("Book name must at least 4 characters!");

            RuleFor(b => b.ShelfChar)
                .NotEmpty()
                .WithMessage("Shelf char required!");

            RuleFor(b => b.ShelfNumber)
                .NotEmpty()
                .WithMessage("Shelf number required!");
        }
    }

    public class CreateBookRequestValidator : AbstractValidator<CreateBookRequest>
    {
        public CreateBookRequestValidator()
        {
            RuleFor(x => x.Book).SetValidator(new BookValidator());
        }
    }

    public class UpdateBookRequestValidator : AbstractValidator<UpdateBookRequest>
    {
        public UpdateBookRequestValidator()
        {
            RuleFor(x => x.Book).SetValidator(new BookValidator());
        }
    }
}
