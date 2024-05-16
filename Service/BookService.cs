using LABAPP.Entities;
using Microsoft.EntityFrameworkCore;
using ProjektInzOp.Dto;
using ProjektInzOp.Extensions;
using System.Numerics;

namespace ProjektInzOp.Service
{
    public class BookService : ServiceBase<Book, BookDto>
    {
        public BookService(LibraryDbcontext dbContext) : base(dbContext)
        {
        }
        public async Task<BookDto> GetById(long id)
        {
            var entity = await base.GetById(id);

            return entity.ToDto();
        }

        public async Task<IEnumerable<BookDto>> Get()
        {
            var entity = await base.Get();

            return entity.Select(e => e.ToDto());
        }

        public async Task<BookDto> Create(BookDto dto)
        {
            var entity = dto.ToEntity();
            await base.Create(entity);


            var newDto = await GetById(entity.Id);

            return newDto;
        }
        public async Task<bool> Update(Book newentity)
        {

            Book entity = await _dbContext.Set<Book>().SingleOrDefaultAsync(e => e.Id == newentity.Id);
            if (entity == null)
            {
                return false;
            }
            entity.TitleId = newentity.TitleId;
            entity.Borrows=newentity.Borrows;
            entity.Borrowed=newentity.Borrowed;
            _dbContext.SaveChanges();
            return true;
        }

        public async Task<bool> BorrowBook(long bookId, long userId)
        {
            
            Book entity = await _dbContext.Set<Book>().SingleOrDefaultAsync(e => e.Id == bookId);
            if (entity.Borrowed==false) {
                Borrow x = _dbContext.Set<Borrow>().ToList().LastOrDefault();
                long value;
                if (x != null) { value = x.Id + 1; } else { value = 1; };
            Borrow borrow = new Borrow { BookId=bookId,
                                        ReaderId=userId,
                                        BorrowDate=DateTime.Now,
                                        Id= value,
            };
                entity.Borrowed = true;
                _dbContext.Set<Borrow>().Add(borrow);
                _dbContext.SaveChanges();
            return true;
            }
            return false;
        }
        public async Task<bool> ReturnBook(long bookId)
        {
            Book entity =  _dbContext.Set<Book>().SingleOrDefault(e => e.Id == bookId);
            Borrow borrow = _dbContext.Set<Borrow>().Where(e => e.BookId == bookId).ToList().Last();
            borrow.ReturnDate = DateTime.Now;
            entity.Borrowed = false;

            borrow.Fine =  ((borrow.ReturnDate-borrow.BorrowDate).Days-14)*15;
            if(borrow.Fine<0) borrow.Fine = 0;
            _dbContext.SaveChanges();
            return true;
        }
    }
}
