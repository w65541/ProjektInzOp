using LABAPP.Entities;
using ProjektInzOp.Dto;

namespace ProjektInzOp.Extensions
{
    public static class ReaderExtension
    {
        public static Reader ToEntity(this ReaderDto dto)
        {
            return new Reader
            {
                Id = dto.Id,
                Name = dto.Name,
                Surname = dto.Surname,
                Addres = dto.Addres,
                Email = dto.Email,
                Phone = dto.Phone,
                
            };
        }

        public static ReaderDto ToDto(this Reader entity)
        {
            return new ReaderDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Surname = entity.Surname,
                Addres= entity.Addres,
                Email = entity.Email,
                Phone = entity.Phone,
            };
        }
    }
}
