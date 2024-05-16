using LABAPP.Entities;
using ProjektInzOp.Dto;

namespace ProjektInzOp.Extensions
{
    public static class BorrowExtension
    {
        public static Borrow ToEntity(this BorrowDto dto)
        {
            return new Borrow
            {
                Id = dto.Id,
                Fine = dto.Fine,
                    BookId = dto.BookId,
                BorrowDate = dto.BorrowDate,
                ReaderId = dto.ReaderId,
                ReturnDate = dto.ReturnDate
            };
        }

        public static BorrowDto ToDto(this Borrow entity)
        {
            return new BorrowDto
            {
                Id = entity.Id,
                Fine = entity.Fine,
                BookId = entity.BookId,
                BorrowDate = entity.BorrowDate,
                ReaderId = entity.ReaderId,
                ReturnDate = entity.ReturnDate
            };
        }
    }
}
