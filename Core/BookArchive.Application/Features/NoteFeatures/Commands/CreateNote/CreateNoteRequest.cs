using BookArchive.Domain.DTOs;
using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Commands.CreateNote
{
    public class CreateNoteRequest : IRequest<CreateNoteResponse>
    {
        public NoteDTO Note { get; set; }
    }
}
