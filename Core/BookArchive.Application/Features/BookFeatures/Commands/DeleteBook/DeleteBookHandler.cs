using AutoMapper;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.BookFeatures.Commands.DeleteBook
{
    public class DeleteBookHandler : IRequestHandler<DeleteBookRequest, DeleteBookResponse>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteBookHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<DeleteBookResponse> Handle(DeleteBookRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteBookResponse();
            var book = await _unitOfWork.GetReadRepository<Book>().GetAsync(x => x.Id == request.BookId);

            _unitOfWork.GetWriteRepository<Book>().Delete(book);
            await _unitOfWork.SaveAsync();

            return response;
        }
    }
}
