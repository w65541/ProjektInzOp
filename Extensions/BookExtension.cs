using LABAPP.Entities;
using ProjektInzOp.Dto;

namespace ProjektInzOp.Extensions
{
    public static class BookExtension
    {
        public static Book ToEntity(this BookDto dto)
        {
            return new Book
            {
                Id = dto.Id,
                
                Borrowed = dto.Borrowed,
                TitleId = dto.TitleId,
            };
        }

        public static BookDto ToDto(this Book entity)
        {
            return new BookDto
            {
                Id = entity.Id,
                Borrowed= entity.Borrowed,
                TitleId= entity.TitleId,
                
            };
        }
    }
}
