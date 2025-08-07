using TestIdentity.Application.DTOs;

namespace TestIdentity.Application.Interfaces;

public interface IService<TEntity, TDto> 
    where TEntity :class
    where TDto :class
{
   Task<TDto?> GetByIdAsync(Guid id);
    Task<IEnumerable<TDto>> GetAllAsync();
    Task<bool> CreateAsync(TDto dto);
    Task<bool> UpdateAsync(TDto dto);
    Task<bool> DeleteAsync(Guid id);
}
