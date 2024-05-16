using LABAPP.Entities;
using ProjektInzOp.Dto;

namespace ProjektInzOp.Extensions
{
    public static class TitleExtension
    {
        public static Title ToEntity(this TitleDto dto)
        {
            return new Title
            {
                Id = dto.Id,
                Name = dto.Name,
                AuthorId = dto.AuthorId,
           
            };
        }

        public static TitleDto ToDto(this Title entity)
        {
            return new TitleDto
            {
                Id = entity.Id,
                Name = entity.Name,
                AuthorId = entity.AuthorId,
               
            };
        }
    }
}
