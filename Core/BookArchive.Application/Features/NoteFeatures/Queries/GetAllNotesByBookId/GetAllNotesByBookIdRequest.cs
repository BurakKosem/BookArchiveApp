using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Queries.GetAllNotesByBookId
{
    public class GetAllNotesByBookIdRequest : IRequest<IList<GetAllNotesByBookIdResponse>>
    {
        public Guid BookId { get; set; }
    }
}
