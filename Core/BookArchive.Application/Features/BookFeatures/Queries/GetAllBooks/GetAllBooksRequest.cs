using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Queries.GetAllBooks
{
    public class GetAllBooksRequest : IRequest<IList<GetAllBooksResponse>>
    {
    }
}
