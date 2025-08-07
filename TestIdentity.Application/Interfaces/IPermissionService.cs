using TestIdentity.Application.DTOs;

namespace TestIdentity.Application.Interfaces;

public interface IPermissionService
{
    Task<IEnumerable<PermissionDto>> GetAllAsync();
    Task<IEnumerable<PermissionDto>> GetByRoleIdAsync(Guid roleId);
    Task AddPermissionToRoleAsync(Guid roleId, PermissionDto permission);
    Task RemovePermissionFromRoleAsync(Guid roleId, Guid permissionId);
}
