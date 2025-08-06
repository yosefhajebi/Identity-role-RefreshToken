using TestIdentity.Application.DTOs;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Interfaces;

namespace TestIdentity.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<UserDto?> GetByUsernameAsync(string username)
    {
        var user = await _userRepo.GetByUsernameAsync(username);
        if (user == null) return null;

        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email.ToString(),
            Roles = user.UserRoles.Select(ur => ur.Role?.Name ?? "").ToList()
        };
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        // فرض بر این است که متدی برای گرفتن همه کاربران در IUserRepository وجود دارد
        throw new NotImplementedException("GetAllAsync needs repository support.");
    }
}
