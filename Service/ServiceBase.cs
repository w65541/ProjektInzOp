using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using ProjektInzOp.Entitites;

namespace ProjektInzOp.Service
{
    public class ServiceBase <TEntity, TDto>
        where TEntity : BaseEntity
        where TDto: class
    {
            public readonly LibraryDbcontext _dbContext;

            public ServiceBase(LibraryDbcontext dbContext) { _dbContext = dbContext; }

            public async Task<bool> Delete(long id)
            {
                var entity = await _dbContext.Set<TEntity>().SingleOrDefaultAsync(e => e.Id.Equals(id));
                if (entity == null)
                {
                    return false;
                }

                _dbContext.Set<TEntity>().Remove(entity);
                 _dbContext.SaveChanges();
                return true;
            }

            public async Task<long> Create(TEntity entity)
            {
                

                _dbContext.Set<TEntity>().Add(entity);
            _dbContext.SaveChanges();
            return entity.Id;

            }

            

            public async Task<TEntity> GetById(long id)
            {
                var entity = await _dbContext.Set<TEntity>().AsNoTracking().SingleOrDefaultAsync(e => e.Id.Equals(id));
                return entity;
            }
            public async Task<IEnumerable<TEntity>> Get()
            {
                var entity = await _dbContext.Set<TEntity>().AsNoTracking().ToListAsync();
                return entity;
            }
        }
}

