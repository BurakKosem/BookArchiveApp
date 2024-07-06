using AutoMapper;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.DTOs;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Queries.GetAllNotesByPrivacy
{
    public class GetAllNotesByPrivacyHandler : IRequestHandler<GetAllNotesByPrivacyRequest, IList<GetAllNotesByPrivacyResponse>>
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public GetAllNotesByPrivacyHandler(IMapper mapper, IUnitOfWork uniteOfWork)
        {
            _mapper = mapper;
            _uniteOfWork = uniteOfWork;
        }
        public async Task<IList<GetAllNotesByPrivacyResponse>> Handle(GetAllNotesByPrivacyRequest request, CancellationToken cancellationToken)
        {
            var response = new List<GetAllNotesByPrivacyResponse>();
            var notes = await _uniteOfWork.GetReadRepository<Note>().GetAllAsync(x => x.PrivacySetting == request.PrivacySetting);

            foreach (var note in notes)
            {
                response.Add(new GetAllNotesByPrivacyResponse
                {
                    Note = _mapper.Map<NoteDTO>(note)
                });
            }

            return response;
        }
    }
}
