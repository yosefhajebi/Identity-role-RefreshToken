namespace TestIdentity.Application.Interfaces;

public interface ITokenService
{
    string GenerateAccessToken(Guid userId, List<string> roles);
    string GenerateRefreshToken();
    bool ValidateToken(string token);
}
