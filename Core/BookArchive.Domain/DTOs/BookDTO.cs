namespace BookArchive.Domain.DTOs
{
    public class BookDTO
    {
        public string Name { get; set; }
        public char ShelfChar { get; set; }
        public int ShelfNumber { get; set; }
        public string CoverImage { get; set; }
        public string Author { get; set; }
    }
}
