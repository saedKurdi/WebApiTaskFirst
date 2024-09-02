using aspTask10WebApi.Entities.Abstraction;
using aspTask10WebApi.Repository.Abstract;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace aspTask10WebApi.Repository.Concrete;
public class EFEntityRepositoryBase<TEntity,TContext> 
    : IEntityRepository<TEntity>
    where TEntity : class, IEntity,new()
    where TContext : DbContext
{
    // private fields for injection : 
    private readonly TContext _context;

    // parametric constructor for injection : 
    public EFEntityRepositoryBase(TContext context)
    {
        _context = context;
    }

    // implemented methods from 'IEntityRepository' : 
    public async Task AddAsync(TEntity entity)
    {
        var addedEntity = _context.Entry(entity);
        addedEntity.State = EntityState.Added;
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(TEntity entity)
    {
        var deletedEntity = _context.Entry(entity);
        deletedEntity.State = EntityState.Deleted;
        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(TEntity entity)
    {
        var updatedEntity = _context.Entry(entity);
        updatedEntity.State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
    public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> expression)
            => await _context.Set<TEntity>().SingleOrDefaultAsync(expression);
    public async Task<ICollection<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null)
        => filter == null ? await _context.Set<TEntity>().ToListAsync() : await _context.Set<TEntity>().Where(filter).ToListAsync();
}
