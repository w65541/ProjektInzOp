using LABAPP.Entities;
using Microsoft.EntityFrameworkCore;
using ProjektInzOp.Dto;
using ProjektInzOp.Extensions;

namespace ProjektInzOp.Service
{
    public class TitleService : ServiceBase<Title, TitleDto>
    {
        public TitleService(LibraryDbcontext dbContext) : base(dbContext)
        {
        }
        public async Task<bool> Update(Title newentity)
        {

            Title entity = await _dbContext.Set<Title>().SingleOrDefaultAsync(e => e.Id == newentity.Id);
            if (entity == null)
            {
                return false;
            }
            entity.AuthorId = newentity.AuthorId;
            entity.Name = newentity.Name;
            
            _dbContext.SaveChanges();
            return true;
        }
        public async Task<TitleDto> GetById(long id)
        {
            var entity = await base.GetById(id);
            if (entity == null) { return null; }
            return entity.ToDto();
        }
        
        public async Task<IEnumerable<TitleDto>> Get()
        {
            var entity = await base.Get();

            return entity.Select(e => e.ToDto());
        }

        public async Task<TitleDto> Create(TitleDto dto)
        {
            var entity = dto.ToEntity();
            await base.Create(entity);


            var newDto = await GetById(entity.Id);

            return newDto;
        }
    }
}
