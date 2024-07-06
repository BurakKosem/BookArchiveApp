using BookArchive.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace BookArchive.Domain.Identity
{
    public class User : IdentityUser<Guid>
    {
        public ICollection<Note> Notes { get; set; }
    }
}
