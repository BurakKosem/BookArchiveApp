using AutoMapper;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.DTOs;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Queries.GetBookByName
{
    public class GetBookByNameHandler : IRequestHandler<GetBookByNameRequest, GetBookByNameResponse>
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public GetBookByNameHandler(IMapper mapper, IUnitOfWork uniteOfWork)
        {
            _mapper = mapper;
            _uniteOfWork = uniteOfWork;
        }
        public async Task<GetBookByNameResponse> Handle(GetBookByNameRequest request, CancellationToken cancellationToken)
        {
            var book = await _uniteOfWork.GetReadRepository<Book>().GetAsync(x => x.Name == request.Name);

            var response = new GetBookByNameResponse
            {
                Book = _mapper.Map<BookDTO>(book)
            };

            return response;
        }
    }
}
