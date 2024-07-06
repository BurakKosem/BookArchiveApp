using AutoMapper;
using BookArchive.Domain.DTOs;
using BookArchive.Domain.Entities;

namespace BookArchive.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDTO>().ReverseMap();
            CreateMap<Note, NoteDTO>().ReverseMap();
        }
    }
}
