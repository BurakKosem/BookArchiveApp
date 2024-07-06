using BookArchive.Domain.Enums;

namespace BookArchive.Domain.DTOs
{
    public class NoteDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PrivacySetting PrivacySetting { get; set; }
        public Guid BookId { get; set; }
    }
}
