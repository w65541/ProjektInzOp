using LABAPP.Entities;
using Microsoft.EntityFrameworkCore;
using ProjektInzOp.Dto;
using ProjektInzOp.Extensions;

namespace ProjektInzOp.Service
{
    public class AuthorService : ServiceBase<Author, AuthorDto>
    {
        public AuthorService(LibraryDbcontext dbContext) : base(dbContext)
        {
        }

        public async Task<AuthorDto> GetById(long id)
        {
            var entity = await base.GetById(id);
            if (entity == null) { return null; }
            return entity.ToDto();
        }
        public async Task<bool> Update(Author newentity)
        {

            Author entity = await _dbContext.Set<Author>().SingleOrDefaultAsync(e => e.Id==newentity.Id);
            if (entity == null)
            {
                return false;
            }
            entity.Name = newentity.Name;
            entity.Surname = newentity.Surname;
             _dbContext.SaveChanges();
            return true;
        }
        public async Task<IEnumerable<AuthorDto>> Get()
        {
            var entity = await base.Get();

            return entity.Select(e => e.ToDto());
        }

        public async Task<AuthorDto> Create(AuthorDto dto)
        {
            var entity = dto.ToEntity();
            await base.Create(entity);


            var newDto = await GetById(entity.Id);

            return newDto;
        }

    }
}
