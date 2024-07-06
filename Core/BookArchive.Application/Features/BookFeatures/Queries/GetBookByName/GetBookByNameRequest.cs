using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Queries.GetBookByName
{
    public class GetBookByNameRequest : IRequest<GetBookByNameResponse>
    {
        public string Name { get; set; }
    }
}
