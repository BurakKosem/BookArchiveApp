using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Queries.GetBooksByAuthor
{
    public class GetBooksByAuthorRequest : IRequest<IList<GetBooksByAuthorResponse>>
    {
        public string Author { get; set; }
    }
}
