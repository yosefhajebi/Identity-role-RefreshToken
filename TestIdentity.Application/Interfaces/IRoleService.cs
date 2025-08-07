using TestIdentity.Application.DTOs;

namespace TestIdentity.Application.Interfaces;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllAsync();
    Task<RoleDto?> GetByIdAsync(Guid id);
    Task CreateAsync(RoleDto role);
    Task UpdateAsync(Guid id, RoleDto role);
    Task DeleteAsync(Guid id);
}
