using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Commands.DeleteBook
{
    public class DeleteBookRequest : IRequest<DeleteBookResponse>
    {
        public Guid BookId { get; set; }
    }
}
