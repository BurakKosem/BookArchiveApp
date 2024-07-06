using AutoMapper;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.DTOs;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Commands.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookRequest, CreateBookResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<CreateBookResponse> Handle(CreateBookRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateBookResponse();
            var mappedBook = _mapper.Map<Book>(request.Book);

            await _unitOfWork.GetWriteRepository<Book>().AddAsync(mappedBook);
            await _unitOfWork.SaveAsync();

            return response;
        }
    }
}
