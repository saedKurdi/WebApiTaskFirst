using aspTask10WebApi.Entities.Abstraction;
using System.Linq.Expressions;
namespace aspTask10WebApi.Repository.Abstract;
public interface IEntityRepository<T> where T : class,IEntity,new()
{
    // public methods which will be implemented in classes : 
    Task<T> GetAsync(Expression<Func<T,bool>> expression);
    Task<ICollection<T>> GetListAsync(Expression<Func<T,bool>> ? filter = null);
    Task AddAsync(T entity);    
    Task DeleteAsync(T entity);
    Task UpdateAsync(T entity);
}
