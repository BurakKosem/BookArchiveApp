using BookArchive.Domain.Common;
using BookArchive.Domain.Enums;
using BookArchive.Domain.Identity;

namespace BookArchive.Domain.Entities
{
    public class Note : EntityBase
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public PrivacySetting PrivacySetting { get; set; }
        public Guid BookId { get; set; }
        public Book Book { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
    }
}
