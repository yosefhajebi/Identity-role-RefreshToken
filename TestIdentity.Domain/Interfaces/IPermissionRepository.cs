using TestIdentity.Domain.Entities;

namespace TestIdentity.Domain.Interfaces;

public interface IPermissionRepository : IRepository<Permission>
{
    Task<IEnumerable<Permission>> GetByRoleIdAsync(Guid roleId);
}
