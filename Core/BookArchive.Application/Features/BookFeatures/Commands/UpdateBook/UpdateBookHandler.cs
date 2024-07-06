using AutoMapper;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.DTOs;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Commands.UpdateBook
{
    public class UpdateBookHandler : IRequestHandler<UpdateBookRequest, UpdateBookResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<UpdateBookResponse> Handle(UpdateBookRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateBookResponse();
            var book = await _unitOfWork.GetReadRepository<Book>().GetAsync(x => x.Id == request.BookId);
            var mappedBook = _mapper.Map(request.Book, book);

            _unitOfWork.GetWriteRepository<Book>().Update(book);
            await _unitOfWork.SaveAsync();

            return response;
        }
    }
}
