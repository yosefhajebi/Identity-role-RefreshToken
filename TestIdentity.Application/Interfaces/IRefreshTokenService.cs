using TestIdentity.Application.DTOs;
using TestIdentity.Application.Common;

namespace TestIdentity.Application.Interfaces;
public interface IRefreshTokenService
{
    Task<string> GenerateTokenAsync(UserDto user);
    Task<Result<string>> RefreshAsync(string oldToken);
}
