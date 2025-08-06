using TestIdentity.Domain.Entities;

namespace TestIdentity.Domain.Interfaces;

public interface IRoleRepository
{
    Task<Role?> GetByNameAsync(string name);
    Task<List<Role>> GetAllAsync();
    Task AddAsync(Role role);
}
