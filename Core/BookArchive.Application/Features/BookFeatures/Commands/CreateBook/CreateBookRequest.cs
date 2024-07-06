using BookArchive.Domain.DTOs;
using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Commands.CreateBook
{
    public class CreateBookRequest : IRequest<CreateBookResponse>
    {
        public BookDTO Book { get; set; }
    }
}
