using BookArchive.Application.Features.NoteFeatures.Commands.CreateNote;
using BookArchive.Application.Features.NoteFeatures.Commands.UpdateNote;
using BookArchive.Domain.DTOs;
using FluentValidation;

namespace BookArchive.Application.Validations
{
    public class NoteValidator : AbstractValidator<NoteDTO>
    {
        public NoteValidator()
        {
            RuleFor(n => n.Title)
                .NotEmpty()
                .WithMessage("Title required!");

            RuleFor(n => n.Description)
                .NotEmpty()
                .WithMessage("Description required!");
        }
    }
    public class CreateNoteRequestValidator : AbstractValidator<CreateNoteRequest>
    {
        public CreateNoteRequestValidator()
        {
            RuleFor(x => x.Note).SetValidator(new NoteValidator());
        }
    }

    public class UpdateNoteRequestValidator : AbstractValidator<UpdateNoteRequest>
    {
        public UpdateNoteRequestValidator()
        {
            RuleFor(x => x.Note).SetValidator(new NoteValidator());
        }
    }
}
