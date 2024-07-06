using AutoMapper;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Commands.CreateNote
{
    public class CreateNoteHandler : IRequestHandler<CreateNoteRequest, CreateNoteResponse>
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public CreateNoteHandler(IMapper mapper, IUnitOfWork uniteOfWork)
        {
            _mapper = mapper;
            _uniteOfWork = uniteOfWork;
        }
        public async Task<CreateNoteResponse> Handle(CreateNoteRequest request, CancellationToken cancellationToken)
        {
            var response = new CreateNoteResponse();
            var mappedNote = _mapper.Map<Note>(request.Note);

            await _uniteOfWork.GetWriteRepository<Note>().AddAsync(mappedNote);
            await _uniteOfWork.SaveAsync();

            return response;
        }
    }
}
