using AutoMapper;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.DTOs;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Queries.GetAllNotesByBookId
{
    public class GetAllNotesByBookIdHandler : IRequestHandler<GetAllNotesByBookIdRequest, IList<GetAllNotesByBookIdResponse>>
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public GetAllNotesByBookIdHandler(IMapper mapper, IUnitOfWork uniteOfWork)
        {
            _mapper = mapper;
            _uniteOfWork = uniteOfWork;
        }
        public async Task<IList<GetAllNotesByBookIdResponse>> Handle(GetAllNotesByBookIdRequest request, CancellationToken cancellationToken)
        {
            var response = new List<GetAllNotesByBookIdResponse>();
            var notes = await _uniteOfWork.GetReadRepository<Note>().GetAllAsync(x => x.BookId == request.BookId);

            foreach (var note in notes)
            {
                response.Add(new GetAllNotesByBookIdResponse
                {
                    Note = _mapper.Map<NoteDTO>(note)
                });
            }

            return response;
        }
    }
}
