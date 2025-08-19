using TestIdentity.Application.DTOs;

namespace TestIdentity.Application.Interfaces;

public interface IService<TEntity,TCreate, TUpdate, TDto> 
    where TEntity : class
    where TCreate : class
    where TUpdate : class
    where TDto : class
{
    Task<TDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<TCreate> CreateAsync(TCreate dto);
    Task<bool> UpdateAsync(TUpdate dto);
    Task<bool> DeleteAsync(Guid id);
}
