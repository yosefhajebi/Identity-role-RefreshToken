using TestIdentity.Domain.Entities;

namespace TestIdentity.Domain.Interfaces;

public interface IUserRepository
{
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User user);
    Task<bool> ExistsAsync(string username);
}
