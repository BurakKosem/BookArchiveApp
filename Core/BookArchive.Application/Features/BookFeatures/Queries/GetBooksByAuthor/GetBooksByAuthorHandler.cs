using AutoMapper;
using BookArchive.Application.Features.BookFeatures.Queries.GetAllBooks;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.DTOs;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Queries.GetBooksByAuthor
{
    public class GetBooksByAuthorHandler : IRequestHandler<GetBooksByAuthorRequest, IList<GetBooksByAuthorResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public GetBooksByAuthorHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetBooksByAuthorResponse>> Handle(GetBooksByAuthorRequest request, CancellationToken cancellationToken)
        {
            var response = new List<GetBooksByAuthorResponse>();
            var books = await _unitOfWork.GetReadRepository<Book>().GetAllAsync(x => x.Author == request.Author);

            foreach (var book in books)
            {
                response.Add(new GetBooksByAuthorResponse
                {
                    Book = _mapper.Map<BookDTO>(book)
                });
            }

            return response;
        }
    }
}
