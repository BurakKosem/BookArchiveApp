using AutoMapper;
using BookArchive.Application.Features.NoteFeatures.Commands.CreateNote;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Commands.UpdateNote
{
    public class UpdateNoteHandler : IRequestHandler<UpdateNoteRequest, UpdateNoteResponse>
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public UpdateNoteHandler(IMapper mapper, IUnitOfWork uniteOfWork)
        {
            _mapper = mapper;
            _uniteOfWork = uniteOfWork;
        }
        public async Task<UpdateNoteResponse> Handle(UpdateNoteRequest request, CancellationToken cancellationToken)
        {
            var response = new UpdateNoteResponse();
            var note = await _uniteOfWork.GetReadRepository<Note>().GetAsync(x => x.Id == request.NoteId);
            var mappedNote = _mapper.Map(request.Note, note);

            _uniteOfWork.GetWriteRepository<Note>().Update(mappedNote);
            await _uniteOfWork.SaveAsync();

            return response;
        }
    }
}
