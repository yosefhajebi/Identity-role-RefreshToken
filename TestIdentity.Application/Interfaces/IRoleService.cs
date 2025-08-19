using TestIdentity.Application.DTOs.Role;

namespace TestIdentity.Application.Interfaces;

public interface IRoleService
{
    Task<RoleDto?> GetByRoleNameAsync(string roleName); 
}
