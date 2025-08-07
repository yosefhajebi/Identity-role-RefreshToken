using TestIdentity.Domain.Interfaces;
using TestIdentity.Domain.Entities;

namespace TestIdentity.Infrastructure.Persistence.Repositories;
public class TokenDomainService : ITokenDomainService
{
    public Token GenerateToken(User user)
    {
        return new Token
        {
            Value = GenerateRandomTokenValue(),
            UserId = user.Id,
            ExpiresAt = DateTime.UtcNow.AddMinutes(30)
        };
    }

    public bool IsTokenValid(Token token)
    {
        return !IsTokenExpired(token) && !string.IsNullOrWhiteSpace(token.Value);
    }

    public bool IsTokenExpired(Token token)
    {
        return DateTime.UtcNow > token.ExpiresAt;
    }

    private string GenerateRandomTokenValue()
    {
        return Convert.ToBase64String(Guid.NewGuid().ToByteArray());
    }
}
