namespace TestIdentity.Application.Interfaces;

public interface ITokenApplicationService
{
    string GenerateAccessToken(Guid userId, List<string> roles);
    string GenerateRefreshToken();
    bool ValidateToken(string token);
}
