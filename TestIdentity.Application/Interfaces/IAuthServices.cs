using TestIdentity.Application.DTOs;

namespace TestIdentity.Application.Interfaces;

public interface IAuthService
{
    Task<UserDto> RegisterAsync(RegisterUserDto dto);
    Task<UserDto> LoginAsync(LoginDto dto);
   // Task<AuthResultDto> RefreshTokenAsync(string token);
}
