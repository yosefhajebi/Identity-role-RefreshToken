using TestIdentity.Application.DTOs;
using TestIdentity.Application.Exceptions;
using TestIdentity.Application.Interfaces;
using TestIdentity.Domain.Entities;
using TestIdentity.Domain.Interfaces;
using TestIdentity.Domain.ValueObjects;

namespace TestIdentity.Application.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;
    private readonly IRoleRepository _roleRepo;

    public AuthService(IUserRepository userRepo, IRoleRepository roleRepo)
    {
        _userRepo = userRepo;
        _roleRepo = roleRepo;
    }

    public async Task<UserDto> RegisterAsync(RegisterUserDto dto)
    {
        if (await _userRepo.ExistsAsync(dto.Username))
            throw new AppException("Username already exists.");

        var email = new Email(dto.Email);
        var passwordHash = HashPassword(dto.Password); // فرضی

        var user = new User(dto.Username, email, passwordHash);

        var defaultRole = await _roleRepo.GetByNameAsync("User");
        if (defaultRole != null)
            user.AssignRole(defaultRole);

        await _userRepo.AddAsync(user);

        return ToUserDto(user);
    }

    public async Task<UserDto> LoginAsync(LoginDto dto)
    {
        var user = await _userRepo.GetByUsernameAsync(dto.Username);
        if (user == null || !VerifyPassword(dto.Password, user.PasswordHash))
            throw new AppException("Invalid credentials.");

        return ToUserDto(user);
    }

    private string HashPassword(string password)
    {
        // فقط برای نمونه
        return Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(password));
    }

    private bool VerifyPassword(string password, string hash)
    {
        return HashPassword(password) == hash;
    }

    private UserDto ToUserDto(User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Username = user.Username,
            Email = user.Email.ToString(),
            Roles = user.UserRoles.Select(ur => ur.Role?.Name ?? "").ToList()
        };
    }
    // public async Task<AuthResultDto> RefreshTokenAsync(string token)
    // {
    //     var refreshToken = await _context.RefreshTokens
    //         .Include(rt => rt.User)
    //         .FirstOrDefaultAsync(rt => rt.Token == token && !rt.IsRevoked);

    //     if (refreshToken == null || refreshToken.Expires < DateTime.UtcNow)
    //         throw new Exception("Invalid or expired refresh token");

    //     // revoke old token
    //     refreshToken.IsRevoked = true;

    //     // generate new tokens
    //     var jwtToken = _jwtService.GenerateToken(refreshToken.User!);
    //     var newRefreshToken = new RefreshToken
    //     {
    //         Token = _jwtService.GenerateRefreshToken(),
    //         Expires = DateTime.UtcNow.AddDays(7),
    //         UserId = refreshToken.UserId
    //     };

    //     _context.RefreshTokens.Add(newRefreshToken);
    //     await _context.SaveChangesAsync();

    //     return new AuthResultDto
    //     {
    //         Token = jwtToken,
    //         RefreshToken = newRefreshToken.Token,
    //         Username = refreshToken.User!.UserName!
    //     };
    // }

}
