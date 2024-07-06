using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Queries.GetBooksByShelf
{
    public class GetBookByShelfRequest : IRequest<IList<GetBookByShelfResponse>>
    {
        public char ShelfChar { get; set; }
        public int ShelfNumber { get; set; }
    }
}
