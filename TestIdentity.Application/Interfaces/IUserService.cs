using TestIdentity.Application.DTOs;

namespace TestIdentity.Application.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetByUsernameAsync(string username);
    Task<List<UserDto>> GetAllAsync();
}
