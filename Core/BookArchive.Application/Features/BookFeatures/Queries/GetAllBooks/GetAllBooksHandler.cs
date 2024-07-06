using AutoMapper;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.DTOs;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Queries.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksRequest, IList<GetAllBooksResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllBooksHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetAllBooksResponse>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
        {
            var response = new List<GetAllBooksResponse>();
            var books = await _unitOfWork.GetReadRepository<Book>().GetAllAsync();

            foreach (var book in books)
            {
                response.Add(new GetAllBooksResponse
                {
                    Book = _mapper.Map<BookDTO>(book)
                });
            }

            return response;
        }
    }
}
