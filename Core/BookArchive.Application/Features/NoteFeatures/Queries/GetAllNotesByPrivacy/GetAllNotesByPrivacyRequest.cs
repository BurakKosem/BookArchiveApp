using BookArchive.Domain.Enums;
using MediatR;

namespace BookArchive.Application.Features.NoteFeatures.Queries.GetAllNotesByPrivacy
{
    public class GetAllNotesByPrivacyRequest : IRequest<IList<GetAllNotesByPrivacyResponse>>
    {
        public PrivacySetting PrivacySetting { get; set; }
    }
}
