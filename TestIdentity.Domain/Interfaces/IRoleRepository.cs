using TestIdentity.Domain.Entities;

namespace TestIdentity.Domain.Interfaces;

public interface IRoleRepository : IRepository<Role>
{
    Task<Role?> GetByNameAsync(string roleName);
}
