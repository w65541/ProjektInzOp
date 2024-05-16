using LABAPP.Entities;
using Microsoft.EntityFrameworkCore;
using ProjektInzOp.Dto;
using ProjektInzOp.Extensions;

namespace ProjektInzOp.Service
{
    public class ReaderService : ServiceBase<Reader, ReaderDto>
    {
        public ReaderService(LibraryDbcontext dbContext) : base(dbContext)
        {
        }

        public async Task<ReaderDto> GetById(long id)
        {
            var entity = await base.GetById(id);

            return entity.ToDto();
        }

        public async Task<IEnumerable<ReaderDto>> Get()
        {
            var entity = await base.Get();

            return entity.Select(e => e.ToDto());
        }

        public async Task<ReaderDto> Create(ReaderDto dto)
        {
            var entity = dto.ToEntity();
            await base.Create(entity);


            var newDto = await GetById(entity.Id);

            return newDto;
        }
        public async Task<bool> Update(Reader newentity)
        {

            Reader entity = await _dbContext.Set<Reader>().SingleOrDefaultAsync(e => e.Id == newentity.Id);
            if (entity == null)
            {
                return false;
            }
            entity.Surname = newentity.Surname;
            entity.Addres=newentity.Addres;
            entity.Name = newentity.Name;
            entity.Phone = newentity.Phone;
            entity.Email = newentity.Email;

            _dbContext.SaveChanges();
            return true;
        }
    }
}
