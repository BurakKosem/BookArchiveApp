using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Commands.DeleteNote
{
    public class DeleteNoteRequest : IRequest<DeleteNoteResponse>
    {
        public Guid NoteId { get; set; }
    }
}
