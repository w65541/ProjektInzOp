using LABAPP.Entities;
using Microsoft.EntityFrameworkCore;
using ProjektInzOp.Dto;
using ProjektInzOp.Extensions;

namespace ProjektInzOp.Service
{
    public class BorrowService : ServiceBase<Borrow, BorrowDto>
    {
        public BorrowService(LibraryDbcontext dbContext) : base(dbContext)
        {
        }

        public async Task<BorrowDto> GetById(long id)
        {
            var entity = await base.GetById(id);

            return entity.ToDto();
        }

        public async Task<IEnumerable<BorrowDto>> Get()
        {
            var entity = await base.Get();

            return entity.Select(e => e.ToDto());
        }

        public async Task<BorrowDto> Create(BorrowDto dto)
        {
            var entity = dto.ToEntity();
            await base.Create(entity);


            var newDto = await GetById(entity.Id);

            return newDto;
        }

        public async Task<bool> Update(Borrow newentity)
        {

            Borrow entity = await _dbContext.Set<Borrow>().SingleOrDefaultAsync(e => e.Id == newentity.Id);
            if (entity == null)
            {
                return false;
            }
            entity.BookId = newentity.BookId;
            entity.BorrowDate = newentity.BorrowDate;
            entity.ReturnDate = newentity.ReturnDate;
            entity.ReaderId = newentity.ReaderId;
            entity.Fine=newentity.Fine;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
