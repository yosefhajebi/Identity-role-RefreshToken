using TestIdentity.Application.DTOs;
using TestIdentity.Domain.Entities;

namespace TestIdentity.Application.Interfaces;

public interface IUserService:IService<User,>
{
    Task CreateAsync(RegisterRequest request);
    Task UpdateAsync(Guid id, UpdateUserRequest request);
    Task<User> GetByUsernameAsync(string userName);
}
