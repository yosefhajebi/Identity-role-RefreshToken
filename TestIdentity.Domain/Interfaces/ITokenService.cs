using TestIdentity.Domain.Entities;

namespace TestIdentity.Domain.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(User user);
    string GenerateRefreshToken();
    bool ValidateToken(string token);
}
