using BookArchive.Domain.Common;

namespace BookArchive.Domain.Entities
{
    public class Book : EntityBase
    {
        public string Name { get; set; }
        public char ShelfChar { get; set; }
        public int ShelfNumber { get; set; }
        public string CoverImage { get; set; }
        public string Author { get; set; }
        public ICollection<Note> Notes { get; set; }
    }
}
