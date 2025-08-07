using TestIdentity.Domain.Entities;

namespace TestIdentity.Domain.Interfaces;

public interface IResourceRepository:IRepository<Resource>
{
    Task<Resource?> GetByNameAsync(string name);
}
// Task<T?> GetByIdAsync(Guid id);
//     Task<IEnumerable<T>> GetAllAsync();
//     Task<T> AddAsync(T entity);
//     Task UpdateAsync(T entity);
//     Task RemoveAsync(T entity);
//     void Update(T entity);
//     void Remove(T entity);