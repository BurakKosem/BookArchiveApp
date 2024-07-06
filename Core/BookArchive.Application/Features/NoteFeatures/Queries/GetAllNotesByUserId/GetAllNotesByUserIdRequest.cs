using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Queries.GetAllNotesByUserId
{
    public class GetAllNotesByUserIdRequest : IRequest<IList<GetAllNotesByUserIdResponse>>
    {
        public Guid UserId { get; set; }
    }
}
