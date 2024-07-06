using AutoMapper;
using BookArchive.Application.Features.NoteFeatures.Queries.GetAllNotesByBookId;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.DTOs;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Queries.GetAllNotesByUserId
{
    public class GetAllNotesByUserIdHandler : IRequestHandler<GetAllNotesByUserIdRequest, IList<GetAllNotesByUserIdResponse>>
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public GetAllNotesByUserIdHandler(IMapper mapper, IUnitOfWork uniteOfWork)
        {
            _mapper = mapper;
            _uniteOfWork = uniteOfWork;
        }
        public async Task<IList<GetAllNotesByUserIdResponse>> Handle(GetAllNotesByUserIdRequest request, CancellationToken cancellationToken)
        {
            var response = new List<GetAllNotesByUserIdResponse>();
            var notes = await _uniteOfWork.GetReadRepository<Note>().GetAllAsync(x => x.UserId == request.UserId);

            foreach (var note in notes)
            {
                response.Add(new GetAllNotesByUserIdResponse
                {
                    Note = _mapper.Map<NoteDTO>(note)
                });
            }

            return response;
        }
    }
}
