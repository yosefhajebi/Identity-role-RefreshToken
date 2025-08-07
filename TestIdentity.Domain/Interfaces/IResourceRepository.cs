using TestIdentity.Domain.Entities;

namespace TestIdentity.Domain.Interfaces;

public interface IResourceRepository
{
    Task<Resource?> GetByNameAsync(string name);
    Task<Resource> AddAsync(Resource resource);
    Task<List<Resource>> GetAllAsync();
    Task<Resource?> GetByIdAsync(Guid id);
    Task UpdateAsync(Resource resource);
    Task DeleteAsync(Guid id);
}
