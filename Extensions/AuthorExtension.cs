using LABAPP.Entities;
using ProjektInzOp.Dto;

namespace ProjektInzOp.Extensions
{
    public static class AuthorExtension
    {
        public static Author ToEntity(this AuthorDto dto)
        {
            return new Author
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
            };
        }

        public static AuthorDto ToDto(this Author entity)
        {
            return new AuthorDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
            };
        }
    }
}
