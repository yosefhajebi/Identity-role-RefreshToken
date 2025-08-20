using TestIdentity.Application.DTOs;

namespace TestIdentity.Application.Interfaces;

public interface IAuthService
{
    Task<AuthResponse> LoginAsync(LoginRequest request);
    Task LogoutAsync(Guid userId);
    Task<string> RefreshTokenAsync(string refreshToken);
    Task<bool> RegisterAsync(RegisterUserRequest registerDto);
}
