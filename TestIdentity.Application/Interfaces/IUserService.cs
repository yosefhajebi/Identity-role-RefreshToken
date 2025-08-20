using TestIdentity.Application.DTOs;
using TestIdentity.Application.DTOs.Role;
using TestIdentity.Domain.Entities;

namespace TestIdentity.Application.Interfaces;

public interface IUserService//:IService<User,RegisterRequest,UpdateUserRequest,UserDto>
{
    Task CreateAsync(RegisterRequest request);
    //Task UpdateAsync(Guid id, UpdateUserRequest request);
    Task<User?> GetByUsernameAsync(string userName);
    Task<bool> IsEmailTakenAsync(string email);
    Task<IEnumerable<RoleDto>> GetUserRolById(Guid userId);
}
