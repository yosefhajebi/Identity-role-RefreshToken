using TestIdentity.Application.DTOs;

namespace TestIdentity.Application.Interfaces;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(Guid id);
    Task CreateAsync(RegisterRequest request);
    Task UpdateAsync(Guid id, UpdateUserRequest request);
    Task DeleteAsync(Guid id);
}
