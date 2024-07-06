using BookArchive.Domain.DTOs;

namespace BookArchive.Application.Features.BookFeatures.Queries.GetBooksByAuthor
{
    public class GetBooksByAuthorResponse
    {
        //public string Name { get; set; }
        //public char ShelfChar { get; set; }
        //public int ShelfNumber { get; set; }
        //public string Image { get; set; }
        //public string Author { get; set; }
        public BookDTO Book { get; set; }
    }
}
