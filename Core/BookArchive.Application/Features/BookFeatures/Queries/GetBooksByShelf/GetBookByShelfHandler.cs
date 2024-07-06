using AutoMapper;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.DTOs;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Queries.GetBooksByShelf
{
    public class GetBookByShelfHandler : IRequestHandler<GetBookByShelfRequest, IList<GetBookByShelfResponse>>
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public GetBookByShelfHandler(IMapper mapper, IUnitOfWork uniteOfWork)
        {
            _mapper = mapper;
            _uniteOfWork = uniteOfWork;
        }
        public async Task<IList<GetBookByShelfResponse>> Handle(GetBookByShelfRequest request, CancellationToken cancellationToken)
        {
            var response = new List<GetBookByShelfResponse>();
            var books = await _uniteOfWork.GetReadRepository<Book>().GetAllAsync(x => (x.ShelfChar == request.ShelfChar && x.ShelfNumber == request.ShelfNumber));

            foreach (var book in books) 
            {
                response.Add(new GetBookByShelfResponse
                {
                    Book = _mapper.Map<BookDTO>(book)
                });    
            }

            return response;
        }
    }
}
