using TestIdentity.Domain.Common;
namespace TestIdentity.Domain.Entities;

using TestIdentity.Domain.Enums;

public class RefreshToken : BaseEntity
{
    public string Token { get; set; } = string.Empty;
    public DateTime ExpiresAt { get; set; }
    public bool IsRevoked { get; set; }

    public string UserId { get; set; } = string.Empty;
    public TokenStatus Status =>
        IsRevoked ? TokenStatus.Revoked :
        ExpiresAt < DateTime.UtcNow ? TokenStatus.Expired :
        TokenStatus.Active;
}
