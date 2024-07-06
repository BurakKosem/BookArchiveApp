using BookArchive.Domain.DTOs;
using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Commands.UpdateBook
{
    public class UpdateBookRequest : IRequest<UpdateBookResponse>
    {
        public Guid BookId { get; set; }
        public BookDTO Book { get; set; }
    }
}
