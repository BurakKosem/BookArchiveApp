using BookArchive.Domain.DTOs;
using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Commands.UpdateNote
{
    public class UpdateNoteRequest : IRequest<UpdateNoteResponse>
    {
        public Guid NoteId { get; set; }
        public NoteDTO Note { get; set; }
    }
}
