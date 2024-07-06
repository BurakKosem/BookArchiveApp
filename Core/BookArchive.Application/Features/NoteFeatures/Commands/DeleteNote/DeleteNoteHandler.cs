using AutoMapper;
using BookArchive.Application.Features.NoteFeatures.Commands.CreateNote;
using BookArchive.Application.Interfaces.UnitOfWork;
using BookArchive.Domain.Entities;
using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Commands.DeleteNote
{
    public class DeleteNoteHandler : IRequestHandler<DeleteNoteRequest, DeleteNoteResponse>
    {
        private readonly IUnitOfWork _uniteOfWork;
        private readonly IMapper _mapper;

        public DeleteNoteHandler(IMapper mapper, IUnitOfWork uniteOfWork)
        {
            _mapper = mapper;
            _uniteOfWork = uniteOfWork;
        }
        public async Task<DeleteNoteResponse> Handle(DeleteNoteRequest request, CancellationToken cancellationToken)
        {
            var response = new DeleteNoteResponse();
            var note = await _uniteOfWork.GetReadRepository<Note>().GetAsync(x => x.Id == request.NoteId);

            _uniteOfWork.GetWriteRepository<Note>().Delete(note);
            await _uniteOfWork.SaveAsync();

            return response;
        }
    }
}
